using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MathCity.Domain.Enums;

namespace MathCity.Infrastructure.Services;

public class LessonService : ILessonService
{
    private readonly ApplicationDbContext _context;

    public LessonService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LessonResponse> CreateAsync(CreateLessonRequest request)
    {
        var topicExists = await _context.Topics
            .AnyAsync(x => x.Id == request.TopicId);

        if (!topicExists)
            throw new NotFoundException("Topic not found.");

        var slug = GenerateSlug(request.Title);

        var exists = await _context.Lessons
            .AnyAsync(x => x.Slug == slug);

        if (exists)
            throw new ConflictException("Lesson already exists.");

        var lesson = new Lesson
        {
            TopicId = request.TopicId,
            Title = request.Title,
            Slug = slug,
            Summary = request.Summary,
            Content = request.MarkdownContent,
            Difficulty = request.Difficulty,
            ReadingTimeMinutes = request.ReadingTimeMinutes,
            IsPublished = request.IsPublished
        };

        _context.Lessons.Add(lesson);

        await _context.SaveChangesAsync();

        return MapToResponse(lesson);
    }

    public async Task<IReadOnlyList<LessonListResponse>> GetAllAsync()
    {
        return await _context.Lessons
            .OrderBy(x => x.Title)
            .Select(x => new LessonListResponse
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                Difficulty = x.Difficulty,
                ReadingTimeMinutes = x.ReadingTimeMinutes,
                IsPublished = x.IsPublished
            })
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LessonListResponse>> GetByTopicAsync(Guid topicId)
    {
        return await _context.Lessons
            .Where(x => x.TopicId == topicId)
            .OrderBy(x => x.Title)
            .Select(x => new LessonListResponse
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                Difficulty = x.Difficulty,
                ReadingTimeMinutes = x.ReadingTimeMinutes,
                IsPublished = x.IsPublished
            })
            .ToListAsync();
    }

    public async Task<LessonResponse> GetByIdAsync(Guid id)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        return MapToResponse(lesson);
    }

    public async Task<LessonResponse> UpdateAsync(Guid id, UpdateLessonRequest request)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        lesson.Title = request.Title;
        lesson.Summary = request.Summary;
        lesson.Content = request.MarkdownContent;
        lesson.Difficulty = request.Difficulty;
        lesson.ReadingTimeMinutes = request.ReadingTimeMinutes;
        lesson.IsPublished = request.IsPublished;

        lesson.Slug = GenerateSlug(request.Title);

        await _context.SaveChangesAsync();

        return MapToResponse(lesson);
    }

    public async Task DeleteAsync(Guid id)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        _context.Lessons.Remove(lesson);

        await _context.SaveChangesAsync();
    }

    private static LessonResponse MapToResponse(Lesson lesson)
    {
        return new LessonResponse
        {
            Id = lesson.Id,
            TopicId = lesson.TopicId,
            Title = lesson.Title,
            Slug = lesson.Slug,
            Summary = lesson.Summary,
            MarkdownContent = lesson.Content,
            Difficulty = lesson.Difficulty,
            ReadingTimeMinutes = lesson.ReadingTimeMinutes,
            IsPublished = lesson.IsPublished
        };
    }

    private static string GenerateSlug(string title)
    {
        return title.Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    }
}