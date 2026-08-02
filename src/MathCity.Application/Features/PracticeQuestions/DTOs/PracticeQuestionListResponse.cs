using MathCity.Domain.Enums;

namespace MathCity.Application.Features.PracticeQuestions.DTOs;

public class PracticeQuestionListResponse
{
    public Guid Id { get; set; }

    public Guid LessonId { get; set; }

    public string LessonTitle { get; set; } = string.Empty;

    public string Question { get; set; } = string.Empty;

    public DifficultyLevel Difficulty { get; set; }

    public int DisplayOrder { get; set; }
}