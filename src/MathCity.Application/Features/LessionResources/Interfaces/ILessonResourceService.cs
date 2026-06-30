using MathCity.Application.Features.LessonResources.DTOs;

namespace MathCity.Application.Features.LessonResources.Interfaces;

public interface ILessonResourceService
{
    Task<LessonResourceResponse> CreateAsync(CreateLessonResourceRequest request);

    Task<IReadOnlyList<LessonResourceListResponse>> GetAllAsync();

    Task<LessonResourceResponse> GetByIdAsync(Guid id);

    Task<IReadOnlyList<LessonResourceListResponse>> GetByLessonAsync(Guid lessonId);

    Task<LessonResourceResponse> UpdateAsync(
        Guid id,
        UpdateLessonResourceRequest request);

    Task DeleteAsync(Guid id);
}