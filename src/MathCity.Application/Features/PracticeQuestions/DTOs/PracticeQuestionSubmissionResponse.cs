namespace MathCity.Application.Features.PracticeQuestions.DTOs;

public class PracticeQuestionSubmissionResponse
{
    public Guid LessonId { get; set; }

    public int TotalQuestions { get; set; }

    public int CorrectAnswers { get; set; }

    public int ScorePercentage { get; set; }

    public bool Passed { get; set; }

    public List<QuestionResultResponse> Results { get; set; } = [];
}