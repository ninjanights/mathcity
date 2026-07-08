using MathCity.Application.Features.Storage.DTOs;
using MathCity.Application.Features.Storage.Interfaces;
using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using SkiaSharp;

namespace MathCity.Infrastructure.Storage;

public class SupabaseStorageService : IFileStorageService
{
    private readonly HttpClient _httpClient;
    private readonly SupabaseSettings _settings;
    private readonly UploadOptions _uploadOptions;

    public SupabaseStorageService(
        HttpClient httpClient,
        IOptions<SupabaseSettings> settings,
         IOptions<UploadOptions> uploadOptions)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
        _uploadOptions = uploadOptions.Value;

        // Normalize ProjectUrl (no trailing slash)
        var baseUrl = _settings.ProjectUrl?.TrimEnd('/');
        _httpClient.BaseAddress = new Uri(baseUrl ?? string.Empty);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _settings.ServiceRoleKey);
       
    }


    public async Task<FileUploadResponse> UploadAsync(
        Stream stream,
        string fileName,
        string contentType,
        string folder,
        bool generateUniqueName = true,
        CancellationToken cancellationToken = default)
    {
        // sanitize folder - disallow path separators
        if (string.IsNullOrWhiteSpace(folder) ||
            folder.Contains(Path.DirectorySeparatorChar) ||
            folder.Contains(Path.AltDirectorySeparatorChar))
            throw new InvalidOperationException("Invalid upload folder.");

        // prepare allowed sets (case-insensitive)
        var allowedFolders = new HashSet<string>(_uploadOptions.AllowedFolders ?? new List<string>(), StringComparer.OrdinalIgnoreCase);
        if (!allowedFolders.Contains(folder))
            throw new InvalidOperationException("Invalid upload folder.");

        // ensure extension and validate
        var extension = Path.GetExtension(fileName)?.ToLowerInvariant() ?? string.Empty;
        var allowedExts = new HashSet<string>((_uploadOptions.AllowedExtensions ?? new List<string>())
            .Select(e => e.StartsWith('.') ? e.ToLowerInvariant() : "." + e.ToLowerInvariant()), StringComparer.OrdinalIgnoreCase);

        if (!allowedExts.Contains(extension))
            throw new ArgumentException("File type is not allowed.");

        // Handle non-seekable streams by buffering to memory (bounded by MaxFileSize)
        Stream contentStream = stream;
        bool buffered = false;

        if (!stream.CanSeek)
        {
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms, 81920, cancellationToken);
            ms.Position = 0;
            contentStream = ms;
            buffered = true;
        }
        else
        {
            // reset to start
            try { stream.Position = 0; } catch { }
        }

        // validate size
        var size = contentStream.CanSeek ? contentStream.Length : throw new InvalidOperationException("Unable to determine stream length.");
        if (size > _uploadOptions.MaxFileSize)
        {
            if (buffered && contentStream is MemoryStream mem)
                mem.Dispose();
            throw new InvalidOperationException("File exceeds the maximum allowed size.");
        }

        var finalName = generateUniqueName
      ? $"{Guid.NewGuid()}{extension}"
      : fileName;
        var storagePath = $"{folder}/{finalName}";

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"/storage/v1/object/{_settings.BucketName}/{storagePath}");

        // prevent disposing caller stream by wrapping when not buffered
        if (!buffered)
            request.Content = new StreamContent(new NonDisposableStream(contentStream));
        else
            request.Content = new StreamContent(contentStream);

        request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            if (buffered && contentStream is MemoryStream mem)
                mem.Dispose();
            throw new HttpRequestException($"Supabase upload failed ({response.StatusCode}): {error}");
        }

        var publicUrl = new Uri(new Uri(_settings.ProjectUrl?.TrimEnd('/') ?? string.Empty), $"/storage/v1/object/public/{_settings.BucketName}/{storagePath}").ToString();

        var result = new FileUploadResponse
        {
            FileName = finalName,
            FilePath = storagePath,
            PublicUrl = publicUrl,
            Size = size,
            ContentType = contentType
        };

        // dispose buffered memory stream if created (request disposal will dispose it as well)
        return result;
    }


    public async Task<string> UploadLessonThumbnailAsync(
        Guid lessonId,
        Stream stream,
        string fileName,
        string contentType,
        CancellationToken cancellationToken = default)
    {
        stream.Position = 0;

        using var bitmap = SKBitmap.Decode(stream);

        if (bitmap == null)
            throw new InvalidOperationException("Invalid image.");

        // 4:3 validation
        var ratio = (double)bitmap.Width / bitmap.Height;

        if (Math.Abs(ratio - (4d / 3d)) > 0.05)
            throw new InvalidOperationException("Thumbnail must have a 4:3 aspect ratio.");

        // Resize
        using var resizedBitmap = bitmap.Resize(
            new SKImageInfo(800, 600),
            SKSamplingOptions.Default);

        if (resizedBitmap == null)
            throw new InvalidOperationException("Failed to resize image.");

        using var image = SKImage.FromBitmap(resizedBitmap);

        using var data = image.Encode(SKEncodedImageFormat.Webp, 80);

        using var output = new MemoryStream();

        data.SaveTo(output);

        output.Position = 0;

        var upload = await UploadAsync(
            output,
            $"{lessonId}.webp",
            "image/webp",
            "lesson-thumbnails",
            generateUniqueName: false,
            cancellationToken);

        return upload.PublicUrl;
    }

    public async Task DeleteAsync(
       string filePath,
       CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            return;

        // Convert public URL to storage path if needed
        if (Uri.TryCreate(filePath, UriKind.Absolute, out var uri))
        {
            var prefix = $"/storage/v1/object/public/{_settings.BucketName}/";

            var index = uri.AbsolutePath.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);

            if (index >= 0)
            {
                filePath = uri.AbsolutePath[(index + prefix.Length)..];
            }
        }

        var response = await _httpClient.DeleteAsync(
            $"/storage/v1/object/{_settings.BucketName}/{filePath}",
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);

            throw new HttpRequestException(
                $"Supabase delete failed ({response.StatusCode}): {error}");
        }
    }

    // Wrapper to prevent disposing the original stream when attached to HttpContent
    private sealed class NonDisposableStream : Stream
    {
        private readonly Stream _inner;
        public NonDisposableStream(Stream inner) => _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        public override bool CanRead => _inner.CanRead;
        public override bool CanSeek => _inner.CanSeek;
        public override bool CanWrite => _inner.CanWrite;
        public override long Length => _inner.Length;
        public override long Position { get => _inner.Position; set => _inner.Position = value; }
        public override void Flush() => _inner.Flush();
        public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);
        public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);
        public override void SetLength(long value) => _inner.SetLength(value);
        public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);
        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default) => await _inner.ReadAsync(buffer, cancellationToken);
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => await _inner.ReadAsync(buffer, offset, count, cancellationToken);
        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => await _inner.WriteAsync(buffer, offset, count, cancellationToken);
        protected override void Dispose(bool disposing)
        {
            // Intentionally do not dispose the inner stream
            // base.Dispose(disposing);
        }
    }
}