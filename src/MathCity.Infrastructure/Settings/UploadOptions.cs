namespace MathCity.Infrastructure.Settings;

public class UploadOptions
{
    public const string SectionName = "Upload";

    public long MaxFileSize { get; set; }

    public List<string> AllowedExtensions { get; set; } = [];

    public List<string> AllowedContentTypes { get; set; } = [];

    public List<string> AllowedFolders { get; set; } = [];
}