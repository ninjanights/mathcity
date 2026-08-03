using MathCity.Application.Common.Models;
using MathCity.Application.Features.Tags.DTOs;

namespace MathCity.Application.Features.Tags.Interfaces;

public interface ITagService
{
    Task<TagResponse> CreateAsync(CreateTagRequest request);

    Task<PagedResult<TagListResponse>> GetAllAsync(
    TagQuery query);

    Task<TagResponse> GetByIdAsync(Guid id);

    Task<TagResponse> UpdateAsync(
        Guid id,
        UpdateTagRequest request);

    Task DeleteAsync(Guid id);
}