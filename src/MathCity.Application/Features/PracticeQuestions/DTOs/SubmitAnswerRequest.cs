public class SubmitAnswerRequest
{
    public Guid QuestionId { get; set; }

    public string SelectedAnswer { get; set; } = string.Empty;
}