using MathCity.Domain.Common;
using MathCity.Domain.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public ICollection<LessonTag> LessonTags { get; set; }
        = new List<LessonTag>();
}