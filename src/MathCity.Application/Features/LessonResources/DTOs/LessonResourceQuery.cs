using MathCity.Domain.Enums;

namespace MathCity.Application.Features.LessonResources.DTOs;

public class LessonResourceQuery
{
    public string? LessonSlug { get; set; }
    public string? Search { get; set; }

    public ResourceType? ResourceType { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 5;
}