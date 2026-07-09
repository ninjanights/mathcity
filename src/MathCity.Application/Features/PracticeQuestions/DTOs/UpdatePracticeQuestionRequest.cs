using MathCity.Domain.Enums;

namespace MathCity.Application.Features.PracticeQuestions.DTOs;

public class UpdatePracticeQuestionRequest
{
    public string Question { get; set; } = string.Empty;

    public string OptionA { get; set; } = string.Empty;

    public string OptionB { get; set; } = string.Empty;

    public string OptionC { get; set; } = string.Empty;

    public string OptionD { get; set; } = string.Empty;

    public QuestionOption CorrectAnswer { get; set; }

    public string Explanation { get; set; } = string.Empty;

    public DifficultyLevel Difficulty { get; set; }

    public int DisplayOrder { get; set; }
}