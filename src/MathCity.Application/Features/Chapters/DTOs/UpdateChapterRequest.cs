namespace MathCity.Application.Features.Chapters.DTOs;

public class UpdateChapterRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}