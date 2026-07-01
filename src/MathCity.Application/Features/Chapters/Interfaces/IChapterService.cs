using MathCity.Application.Features.Chapters.DTOs;

namespace MathCity.Application.Features.Chapters.Interfaces;

public interface IChapterService
{
    Task<ChapterResponse> CreateAsync(CreateChapterRequest request);

    Task<IReadOnlyList<ChapterListResponse>> GetAllAsync(
     string? search = null);

    Task<IReadOnlyList<ChapterListResponse>> GetBySubjectAsync(Guid subjectId);

    Task<ChapterResponse> GetByIdAsync(Guid id);



    Task<ChapterResponse> UpdateAsync(
        Guid id,
        UpdateChapterRequest request);

    Task DeleteAsync(Guid id);
}