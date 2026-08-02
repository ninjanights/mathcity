using MathCity.Application.Common.Models;
using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Storage.DTOs;

namespace MathCity.Application.Features.LessonResources.Interfaces;

public interface ILessonResourceService
{
    Task<LessonResourceResponse> CreateAsync(
    CreateLessonResourceRequest request,
    FileUploadResponse upload);

    Task<PagedResult<LessonResourceListResponse>> GetAllAsync(
     LessonResourceQuery query);

    Task<LessonResourceResponse> GetByIdAsync(Guid id);

    Task<IReadOnlyList<LessonResourceListResponse>> GetByLessonAsync(Guid lessonId);

    Task<LessonResourceResponse> UpdateAsync(
        Guid id,
        UpdateLessonResourceRequest request);

    Task MoveAsync(
    Guid id,
    MoveLessonResourceRequest request);

    Task DeleteAsync(Guid id);
}