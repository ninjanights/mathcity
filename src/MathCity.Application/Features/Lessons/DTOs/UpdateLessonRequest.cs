using MathCity.Domain.Enums;

namespace MathCity.Application.Features.Lessons.DTOs;

public class UpdateLessonRequest
{
    public string Title { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string MarkdownContent { get; set; } = string.Empty;

    public DifficultyLevel Difficulty { get; set; }

    public int ReadingTimeMinutes { get; set; }

    public bool IsPublished { get; set; }
}