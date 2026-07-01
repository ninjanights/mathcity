using MathCity.Application.Features.Lessons.DTOs;

namespace MathCity.Application.Features.Lessons.Interfaces;

public interface ILessonService
{
    Task<LessonResponse> CreateAsync(CreateLessonRequest request);

    Task<IReadOnlyList<LessonListResponse>> GetAllAsync();

    Task<LessonResponse> GetByIdAsync(
        Guid lessonId,
        Guid? userId = null);

    Task<IReadOnlyList<LessonListResponse>> GetByTopicAsync(Guid topicId);

    Task<LessonResponse> UpdateAsync(
        Guid id,
        UpdateLessonRequest request);

    Task DeleteAsync(Guid id);
}