namespace MathCity.Application.Features.PracticeQuestions.DTOs;

public class PracticeQuestionListResponse
{
    public Guid Id { get; set; }

    public string Question { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}