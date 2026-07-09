using MathCity.Domain.Enums;

namespace MathCity.Application.Features.PracticeQuestions.DTOs;

public class QuestionResultResponse
{
    public Guid QuestionId { get; set; }

    public QuestionOption SelectedAnswer { get; set; }


    public QuestionOption CorrectAnswer { get; set; }

    public bool IsCorrect { get; set; }

    public string Explanation { get; set; } = string.Empty;
}