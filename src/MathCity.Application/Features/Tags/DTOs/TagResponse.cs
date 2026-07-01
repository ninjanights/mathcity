namespace MathCity.Application.Features.Tags.DTOs;

public class TagResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;
}