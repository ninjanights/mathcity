using MathCity.Domain.Enums;

public class SubmitAnswerRequest
{
    public Guid QuestionId { get; set; }

    public QuestionOption SelectedAnswer { get; set; }
}