namespace MathCity.Application.Features.Bookmarks.DTOs;

public class BookmarkResponse
{
    public Guid Id { get; set; }

    public Guid LessonId { get; set; }

    public string LessonTitle { get; set; } = string.Empty;

    public string LessonSlug { get; set; } = string.Empty;
}