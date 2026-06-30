namespace MathCity.Application.Features.Topics.DTOs;

public class TopicResponse
{
    public Guid Id { get; set; }

    public Guid ChapterId { get; set; }

    public string Title { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}