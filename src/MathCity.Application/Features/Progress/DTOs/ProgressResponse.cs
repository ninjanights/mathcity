namespace MathCity.Application.Features.Progress.DTOs;

public class ProgressResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public int ProgressPercentage { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime LastAccessedAt { get; set; }

    public DateTime? CompletedAt { get; set; }
}