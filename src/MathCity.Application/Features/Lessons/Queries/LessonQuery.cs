using MathCity.Application.Common.Models;
using MathCity.Domain.Enums;

namespace MathCity.Application.Features.Lessons.Queries;

public class LessonQuery : PaginationQuery
{
    public string? Search { get; set; }

    public Guid? TopicId { get; set; }

    public DifficultyLevel? Difficulty { get; set; }

    public bool? Published { get; set; }

    public string? Tag { get; set; }


}