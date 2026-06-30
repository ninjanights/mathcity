using MathCity.Domain.Enums;

namespace MathCity.Application.Features.LessonResources.DTOs;

public class LessonResourceListResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public ResourceType ResourceType { get; set; }

    public int DisplayOrder { get; set; }
}