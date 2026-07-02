namespace MathCity.Application.Features.PracticeQuestions.DTOs;

public class QuestionResultResponse
{
    public Guid QuestionId { get; set; }

    public string SelectedAnswer { get; set; } = string.Empty;

    public string CorrectAnswer { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    public string Explanation { get; set; } = string.Empty;
}