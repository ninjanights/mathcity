using MathCity.Application.Common.Exceptions;
using MathCity.Application.Common.Models;
using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Application.Features.Lessons.Queries;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
            ThumbnailUrl = request.ThumbnailUrl,
            IsPublished = request.IsPublished,
            DisplayOrder = request.DisplayOrder
        };

        _context.Lessons.Add(lesson);

        await _context.SaveChangesAsync();

        return MapToResponse(lesson);
    }

    public async Task<PagedResult<LessonListResponse>> GetAllAsync(
     LessonQuery query)
    {
        var lessons = _context.Lessons
            .AsQueryable();

        // Search by title
        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var search = query.Search.Trim().ToLower();

            lessons = lessons.Where(x =>
                x.Title.ToLower().Contains(search));
        }

        // Filter by Topic
        if (query.TopicId.HasValue)
        {
            lessons = lessons.Where(x =>
                x.TopicId == query.TopicId.Value);
        }

        // Filter by Difficulty
        if (query.Difficulty.HasValue)
        {
            lessons = lessons.Where(x =>
                x.Difficulty == query.Difficulty.Value);
        }

        // Filter by Published
        if (query.Published.HasValue)
        {
            lessons = lessons.Where(x =>
                x.IsPublished == query.Published.Value);
        }

        // Filter by Tag
        if (!string.IsNullOrWhiteSpace(query.Tag))
        {
            var tag = query.Tag.Trim().ToLower();

            lessons = lessons.Where(x =>
                x.LessonTags.Any(t =>
                    t.Tag.Slug == tag ||
                    t.Tag.Name.ToLower() == tag));
        }

        var totalCount = await lessons.CountAsync();

        var items = await lessons
.OrderBy(x => x.DisplayOrder)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new LessonListResponse
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                Difficulty = x.Difficulty,
                ReadingTimeMinutes = x.ReadingTimeMinutes,
                IsPublished = x.IsPublished,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();

        return new PagedResult<LessonListResponse> {
            Items = items,
            Page = query.Page,
            PageSize = query.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(
                totalCount / (double)query.PageSize)
        };
    }

    public async Task<IReadOnlyList<LessonListResponse>> GetByTopicAsync(Guid topicId)
    {
        return await _context.Lessons
            .Where(x => x.TopicId == topicId)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new LessonListResponse
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                Difficulty = x.Difficulty,
                ReadingTimeMinutes = x.ReadingTimeMinutes,
                ThumbnailUrl = x.ThumbnailUrl,
                DisplayOrder = x.DisplayOrder,
                IsPublished = x.IsPublished
            })
            .ToListAsync();
    }

    public async Task<LessonResponse> GetByIdAsync(
        Guid lessonId,
        Guid? userId = null)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == lessonId);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        bool IsBookmarked = false;

        if (userId.HasValue)
        {
            IsBookmarked = await _context.Bookmarks.AnyAsync(x =>
                x.UserId == userId.Value &&
                x.LessonId == lessonId);
        }

        return MapToResponse(lesson, IsBookmarked);
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
        lesson.ThumbnailUrl = request.ThumbnailUrl;
        lesson.IsPublished = request.IsPublished;
        lesson.DisplayOrder = request.DisplayOrder;
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

    private static LessonResponse MapToResponse(
     Lesson lesson,
     bool isBookmarked = false)
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
            ThumbnailUrl = lesson.ThumbnailUrl,
            IsPublished = lesson.IsPublished,
            DisplayOrder = lesson.DisplayOrder,
            IsBookmarked = isBookmarked
        };
    }

    private static string GenerateSlug(string title)
    {
        return title.Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    }

    public async Task MoveAsync(
    Guid id,
    MoveLessonRequest request)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        var total = await _context.Lessons
            .CountAsync(x => x.TopicId == lesson.TopicId);

        var newPosition = Math.Clamp(request.Position, 1, total);

        var oldPosition = lesson.DisplayOrder;

        if (oldPosition == newPosition)
            return;

        if (newPosition < oldPosition)
        {
            var lessons = await _context.Lessons
                .Where(x =>
                    x.TopicId == lesson.TopicId &&
                    x.DisplayOrder >= newPosition &&
                    x.DisplayOrder < oldPosition)
                .ToListAsync();

            foreach (var item in lessons)
                item.DisplayOrder++;
        }
        else
        {
            var lessons = await _context.Lessons
                .Where(x =>
                    x.TopicId == lesson.TopicId &&
                    x.DisplayOrder <= newPosition &&
                    x.DisplayOrder > oldPosition)
                .ToListAsync();

            foreach (var item in lessons)
                item.DisplayOrder--;
        }

        lesson.DisplayOrder = newPosition;

        await _context.SaveChangesAsync();
    }


}