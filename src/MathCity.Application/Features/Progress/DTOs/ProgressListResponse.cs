namespace MathCity.Application.Features.Progress.DTOs;

public class ProgressListResponse
{
    public Guid Id { get; set; }

    public Guid LessonId { get; set; }

    public int ProgressPercentage { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime LastAccessedAt { get; set; }
}