using MathCity.Application.Features.Storage.DTOs;
using MathCity.Application.Features.Storage.Interfaces;
using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using MathCity.Domain.Enums;

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

    public async Task<bool> ExistsAsync(
    string lessonSlug,
    string fileName,
    CancellationToken cancellationToken = default)
    {
        var path = $"resources/{lessonSlug}/{fileName}";
        var url =
       $"{_settings.ProjectUrl.TrimEnd('/')}/storage/v1/object/{_settings.BucketName}/{path}";

        using var request = new HttpRequestMessage(
            HttpMethod.Head,
            url);


        var response = await _httpClient.SendAsync(
            request,
            cancellationToken);
        return response.IsSuccessStatusCode;
    }
    private async Task<FileUploadResponse> UploadAsync(
        Stream stream,
        string fileName,
        string contentType,
        string folder,
        bool generateUniqueName = true,
        CancellationToken cancellationToken = default)
    {
        // sanitize folder - disallow path separators
        if (string.IsNullOrWhiteSpace(folder))
            throw new InvalidOperationException("Invalid upload folder.");

        var allowedFolders = new HashSet<string>(
            _uploadOptions.AllowedFolders ?? new List<string>(),
            StringComparer.OrdinalIgnoreCase);

        var rootFolder = folder.Split('/')[0];

        if (!allowedFolders.Contains(rootFolder))
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

    private static string GenerateResourceFileName(
    string slug,
    string extension)
    {
        return $"{slug}{extension}";
    }

    public async Task<FileUploadResponse> UploadDocumentAsync(
     string lessonSlug,
    ResourceType resourceType,
    Stream stream,
    string contentType,
    CancellationToken cancellationToken = default)
    {
        var folder = $"resources/{lessonSlug}";
        var extension = resourceType switch
        {
            ResourceType.Text => ".txt",
            ResourceType.Pdf => ".pdf",
            _ => throw new InvalidOperationException()
        };
        ValidateResource(
    resourceType,
    extension,
    contentType);
        var finalName = GenerateResourceFileName(lessonSlug, extension);

        if (await ExistsAsync(
        lessonSlug,
        finalName,
        cancellationToken))
        {
            var storagePath = $"{folder}/{finalName}";

            var publicUrl =
                $"{_settings.ProjectUrl.TrimEnd('/')}/storage/v1/object/public/{_settings.BucketName}/{storagePath}";

            return new FileUploadResponse
            {
                FileName = finalName,
                FilePath = storagePath,
                PublicUrl = publicUrl,
                Size = stream.Length,
                ContentType = contentType
            };
        }

        return await UploadAsync(
    stream,
    finalName,
    contentType,
    folder,
    generateUniqueName: false,
    cancellationToken);
    }
    private static readonly string[] PdfExtensions =
[
    ".pdf"
];

    private static readonly string[] PdfContentTypes =
    [
        "application/pdf"
    ];

    private static readonly string[] TextExtensions =
[
    ".txt"
];

    private static readonly string[] TextContentTypes =
    [
        "text/plain"
    ];


    private static void Validate(
    string extension,
    string contentType,
    IEnumerable<string> allowedExtensions,
    IEnumerable<string> allowedContentTypes,
    string name)
    {
        if (!allowedExtensions.Contains(extension))
        {
            throw new InvalidOperationException(
                $"Invalid {name} extension.");
        }

        if (!allowedContentTypes.Contains(
            contentType,
            StringComparer.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Invalid {name} content type.");
        }
    }

    private static void ValidateResource(
    ResourceType type,
    string extension,
    string contentType)
    {
        extension = extension.ToLowerInvariant();

        switch (type)
        {

            case ResourceType.Pdf:

                Validate(
                    extension,
                    contentType,
                    PdfExtensions,
                    PdfContentTypes,
                    "PDF");

                break;


            case ResourceType.Text:

                Validate(
                    extension,
                    contentType,
                    TextExtensions,
                    TextContentTypes,
                    "Text");

                break;


            default:

                throw new InvalidOperationException(
                    $"Unsupported resource type '{type}'.");
        }
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