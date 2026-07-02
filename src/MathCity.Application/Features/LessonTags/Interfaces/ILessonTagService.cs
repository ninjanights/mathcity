using MathCity.Application.Features.LessonTags.DTOs;
using MathCity.Application.Features.LessonTags.Interfaces;

namespace MathCity.Application.Features.LessonTags.Interfaces;

public interface ILessonTagService
{
    Task<LessonTagResponse> CreateAsync(
        Guid lessonId,
        CreateLessonTagRequest request);

    Task<IReadOnlyList<LessonTagResponse>> GetByLessonAsync(
        Guid lessonId);

    Task DeleteAsync(
        Guid lessonId,
        Guid tagId);
}