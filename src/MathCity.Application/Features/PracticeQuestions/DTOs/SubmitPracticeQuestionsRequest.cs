public class SubmitPracticeQuestionsRequest
{
    public Guid LessonId { get; set; }

    public List<SubmitAnswerRequest> Answers { get; set; } = [];
}