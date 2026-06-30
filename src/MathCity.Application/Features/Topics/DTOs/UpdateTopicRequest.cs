namespace MathCity.Application.Features.Topics.DTOs;

public class UpdateTopicRequest
{
    public string Title { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}