using MathCity.Application.Features.Topics.DTOs;

namespace MathCity.Application.Features.Topics.Interfaces;

public interface ITopicService
{
    Task<TopicResponse> CreateAsync(CreateTopicRequest request);

    Task<IReadOnlyList<TopicListResponse>> GetAllAsync(
    string? search = null);


    Task<IReadOnlyList<TopicListResponse>> GetByChapterAsync(Guid chapterId);

    Task<TopicResponse> GetByIdAsync(Guid id);

    Task<TopicResponse> UpdateAsync(
        Guid id,
        UpdateTopicRequest request);

    Task MoveAsync(Guid id, MoveTopicRequest request);

    Task DeleteAsync(Guid id);
}