namespace MathCity.Application.Features.LessonTags.DTOs;

public class LessonTagResponse
{
    public Guid LessonId { get; set; }

    public Guid TagId { get; set; }

    public string TagName { get; set; } = string.Empty;

    public string TagSlug { get; set; } = string.Empty;
}