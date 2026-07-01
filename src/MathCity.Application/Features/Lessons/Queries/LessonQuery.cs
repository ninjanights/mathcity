using MathCity.Domain.Enums;

namespace MathCity.Application.Features.Lessons.Queries;

public class LessonQuery
{
    public string? Search { get; set; }

    public Guid? TopicId { get; set; }

    public DifficultyLevel? Difficulty { get; set; }

    public bool? Published { get; set; }

    public string? Tag { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}