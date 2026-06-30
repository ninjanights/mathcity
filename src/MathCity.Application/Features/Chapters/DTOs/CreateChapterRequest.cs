namespace MathCity.Application.Features.Chapters.DTOs;

public class CreateChapterRequest
{
    public Guid SubjectId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}