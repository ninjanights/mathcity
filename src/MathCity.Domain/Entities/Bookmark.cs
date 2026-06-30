using MathCity.Domain.Common;
using MathCity.Domain.Entities;

public class Bookmark : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;
}