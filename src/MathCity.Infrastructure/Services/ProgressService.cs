using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Progress.DTOs;
using MathCity.Application.Features.Progress.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class ProgressService : IProgressService
{
    private readonly ApplicationDbContext _context;

    public ProgressService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProgressResponse> CreateAsync(
        Guid userId,
        CreateProgressRequest request)
    {
        var lessonExists = await _context.Lessons
            .AnyAsync(x => x.Id == request.LessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

        var existingProgress = await _context.Progress
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.LessonId == request.LessonId);

        if (existingProgress != null)
            throw new ConflictException("Progress already exists for this lesson.");

        var progress = new Progress
        {
            UserId = userId,
            LessonId = request.LessonId,
            ProgressPercentage = request.ProgressPercentage,
            IsCompleted = request.IsCompleted,
            LastAccessedAt = DateTime.UtcNow,
            CompletedAt = request.IsCompleted
                ? DateTime.UtcNow
                : null
        };

        _context.Progress.Add(progress);

        await _context.SaveChangesAsync();

        return MapToResponse(progress);
    }

    public async Task<IReadOnlyList<ProgressListResponse>> GetAllAsync()
    {
        return await _context.Progress
            .OrderByDescending(x => x.LastAccessedAt)
            .Select(x => new ProgressListResponse
            {
                Id = x.Id,
                LessonId = x.LessonId,
                ProgressPercentage = x.ProgressPercentage,
                IsCompleted = x.IsCompleted,
                LastAccessedAt = x.LastAccessedAt
            })
            .ToListAsync();
    }

    public async Task<IReadOnlyList<ProgressListResponse>> GetByUserAsync(Guid userId)
    {
        return await _context.Progress
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.LastAccessedAt)
            .Select(x => new ProgressListResponse
            {
                Id = x.Id,
                LessonId = x.LessonId,
                ProgressPercentage = x.ProgressPercentage,
                IsCompleted = x.IsCompleted,
                LastAccessedAt = x.LastAccessedAt
            })
            .ToListAsync();
    }

    public async Task<ProgressResponse> GetByIdAsync(
        Guid userId,
        Guid progressId)
    {
        var progress = await _context.Progress
      .FirstOrDefaultAsync(x =>
          x.Id == progressId &&
          x.UserId == userId);

        if (progress == null)
            throw new NotFoundException("Progress not found.");

        return MapToResponse(progress);
    }

    public async Task<ProgressResponse> UpdateAsync(
    Guid userId,
    Guid progressId,
    UpdateProgressRequest request)
    {
        var progress = await _context.Progress
     .FirstOrDefaultAsync(x =>
         x.Id == progressId &&
         x.UserId == userId);

        if (progress == null)
            throw new NotFoundException("Progress not found.");

        progress.ProgressPercentage = request.ProgressPercentage;
        progress.IsCompleted = request.IsCompleted;
        progress.LastAccessedAt = DateTime.UtcNow;

        progress.CompletedAt = request.IsCompleted
            ? DateTime.UtcNow
            : null;

        await _context.SaveChangesAsync();

        return MapToResponse(progress);
    }

    public async Task DeleteAsync(
     Guid userId,
     Guid progressId)
    {

        var progress = await _context.Progress
    .FirstOrDefaultAsync(x =>
        x.Id == progressId &&
        x.UserId == userId);

        if (progress == null)
            throw new NotFoundException("Progress not found.");

        _context.Progress.Remove(progress);

        await _context.SaveChangesAsync();
    }


    public async Task StartLessonAsync(
    Guid userId,
    Guid lessonId)
    {

        var lessonExists = await _context.Lessons
    .AnyAsync(x => x.Id == lessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

        var progress = await _context.Progress
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.LessonId == lessonId);

        if (progress != null)
        {
            progress.LastAccessedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return;
        }

        progress = new Progress
        {
            UserId = userId,
            LessonId = lessonId,
            ProgressPercentage = 0,
            IsCompleted = false,
            LastAccessedAt = DateTime.UtcNow
        };

        _context.Progress.Add(progress);

        await _context.SaveChangesAsync();
    }

    public async Task CompleteLessonAsync(
    Guid userId,
    Guid lessonId)


    {
        var progress = await _context.Progress
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.LessonId == lessonId);

      

        if (progress == null)
            throw new NotFoundException("Progress not found.");

        if (progress.IsCompleted)
            return;

        progress.ProgressPercentage = 100;
        progress.IsCompleted = true;
        progress.CompletedAt = DateTime.UtcNow;
        progress.LastAccessedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task<ProgressResponse?> GetLessonProgressAsync(
    Guid userId,
    Guid lessonId)
    {


        var progress = await _context.Progress
            .Include(x => x.Lesson)
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.LessonId == lessonId);

        if (progress == null)
            return null;

        return MapToResponse(progress);
    }

    private static ProgressResponse MapToResponse(Progress progress)
    {
        return new ProgressResponse
        {
            Id = progress.Id,
            UserId = progress.UserId,
            LessonId = progress.LessonId,
            ProgressPercentage = progress.ProgressPercentage,
            IsCompleted = progress.IsCompleted,
            LastAccessedAt = progress.LastAccessedAt,
            CompletedAt = progress.CompletedAt
        };
    }
}