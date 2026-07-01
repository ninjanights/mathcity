using MathCity.Domain.Common;
using MathCity.Domain.Entities;

public class Comment : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public string Content { get; set; } = string.Empty;

}