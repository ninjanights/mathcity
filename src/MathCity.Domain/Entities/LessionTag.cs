using MathCity.Domain.Common;
using MathCity.Domain.Entities;

public class LessonTag : BaseEntity
{
    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public Guid TagId { get; set; }

    public Tag Tag { get; set; } = null!;
}