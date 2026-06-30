namespace MathCity.Application.Features.Progress.DTOs;

public class CreateProgressRequest
{

    public Guid LessonId { get; set; }

    public int ProgressPercentage { get; set; }

    public bool IsCompleted { get; set; }
}