using MathCity.Application.Common.Models;
using MathCity.Application.Features.Chapters.DTOs;

namespace MathCity.Application.Features.Chapters.Interfaces;

public interface IChapterService
{
    Task<ChapterResponse> CreateAsync(CreateChapterRequest request);

    Task<PagedResult<ChapterListResponse>> GetAllAsync(ChapterQuery query);

    Task<IReadOnlyList<ChapterListResponse>> GetBySubjectAsync(Guid subjectId);

    Task<ChapterResponse> GetByIdAsync(Guid id);

    Task MoveAsync(
    Guid id,
    MoveChapterRequest request);

    Task<ChapterResponse> UpdateAsync(
        Guid id,
        UpdateChapterRequest request);

    Task DeleteAsync(Guid id);
}