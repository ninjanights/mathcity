using MathCity.Application.Features.Progress.DTOs;

namespace MathCity.Application.Features.Progress.Interfaces;

public interface IProgressService
{
    Task<ProgressResponse> CreateAsync(
     Guid userId,
     CreateProgressRequest request);

    Task<IReadOnlyList<ProgressListResponse>> GetAllAsync();

    Task<ProgressResponse> GetByIdAsync(
      Guid userId,
      Guid progressId);

    Task<IReadOnlyList<ProgressListResponse>> GetByUserAsync(Guid userId);

    Task<ProgressResponse> UpdateAsync(
     Guid userId,
     Guid progressId,
     UpdateProgressRequest request);

    Task DeleteAsync(
    Guid userId,
    Guid progressId);

    Task StartLessonAsync(
    Guid userId,
    Guid lessonId);

    Task CompleteLessonAsync(
        Guid userId,
        Guid lessonId);

    Task<ProgressResponse?> GetLessonProgressAsync(
        Guid userId,
        Guid lessonId);
}