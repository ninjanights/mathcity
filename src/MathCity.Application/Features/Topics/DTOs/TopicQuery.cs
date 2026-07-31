using MathCity.Application.Common.Models;

namespace MathCity.Application.Features.Topics.DTOs;

public class TopicQuery : PaginationQuery
{
    public string? Search { get; set; }

    public Guid? ChapterId { get; set; }
}