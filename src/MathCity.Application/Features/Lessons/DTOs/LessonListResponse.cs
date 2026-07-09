using MathCity.Domain.Enums;

namespace MathCity.Application.Features.Lessons.DTOs;

public class LessonListResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string TopicTitle {  get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public DifficultyLevel Difficulty { get; set; }

    public int ReadingTimeMinutes { get; set; }

    public string ThumbnailUrl { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; }
}