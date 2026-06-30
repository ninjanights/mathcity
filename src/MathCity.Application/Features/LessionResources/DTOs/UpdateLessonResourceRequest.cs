using MathCity.Domain.Enums;

namespace MathCity.Application.Features.LessonResources.DTOs;

public class UpdateLessonResourceRequest
{
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public ResourceType ResourceType { get; set; }

    public int DisplayOrder { get; set; }
}