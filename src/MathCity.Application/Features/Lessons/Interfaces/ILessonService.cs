using MathCity.Application.Common.Models;
using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Lessons.Queries;

namespace MathCity.Application.Features.Lessons.Interfaces;

public interface ILessonService
{
    Task<LessonResponse> CreateAsync(CreateLessonRequest request);

    Task<PagedResult<LessonListResponse>> GetAllAsync(
     LessonQuery query);

    Task<LessonResponse> GetByIdAsync(
        Guid lessonId,
        Guid? userId = null);

    Task<IReadOnlyList<LessonListResponse>> GetByTopicAsync(Guid topicId);

    Task<LessonResponse> UpdateAsync(
        Guid id,
        UpdateLessonRequest request);

    Task DeleteAsync(Guid id);
}