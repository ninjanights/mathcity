namespace MathCity.Application.Features.Storage.DTOs;

public class FileUploadResponse
{
    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public string PublicUrl { get; set; } = string.Empty;

    public long Size { get; set; }

    public string ContentType { get; set; } = string.Empty;
}