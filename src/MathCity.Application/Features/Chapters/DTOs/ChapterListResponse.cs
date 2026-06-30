namespace MathCity.Application.Features.Chapters.DTOs;

public class ChapterListResponse
{
    public Guid Id { get; set; }

    public Guid SubjectId { get; set; }

    public string Title { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}