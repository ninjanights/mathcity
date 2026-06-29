using MathCity.Domain.Common;

namespace MathCity.Domain.Entities;

public class Progress : BaseEntity
{
    // Identity user who owns this progress
    public Guid UserId { get; set; }

    // Lesson being tracked
    public Guid LessonId { get; set; }

    // Navigation property
    public Lesson Lesson { get; set; } = null!;

    // Progress percentage (0 - 100)
    public int ProgressPercentage { get; set; } = 0;

    // Has the lesson been completed?
    public bool IsCompleted { get; set; } = false;

    // Last time the lesson was opened
    public DateTime LastAccessedAt { get; set; } = DateTime.UtcNow;

    // Completion timestamp (nullable until completed)
    public DateTime? CompletedAt { get; set; }
}