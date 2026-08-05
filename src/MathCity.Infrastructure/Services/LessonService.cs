using MathCity.Application.Common.Exceptions;
using MathCity.Application.Common.Models;
using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Application.Features.Lessons.Queries;
using MathCity.Application.Features.Storage.Interfaces;
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

    public async Task<LessonResponse> CreateAsync(
        CreateLessonRequest request)
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
        
        var maxDisplayOrder = await _context.Lessons
    .Where(x => x.TopicId == request.TopicId)
    .Select(x => (int?)x.DisplayOrder)
    .MaxAsync() ?? 0;

        var lesson = new Lesson
        {
            TopicId = request.TopicId,
            Title = request.Title, 
            Slug = slug,
            Summary = request.Summary,
            Content = request.MarkdownContent,
            Difficulty = request.Difficulty,
            ReadingTimeMinutes = request.ReadingTimeMinutes,
            IsPublished = request.IsPublished,
            DisplayOrder = maxDisplayOrder + 1,

            IsEmbedded = false,
            EmbeddingsGeneratedAt = null
        };

        _context.Lessons.Add(lesson);

        // Generate Lesson Id
        await _context.SaveChangesAsync();

       

      

        return MapToResponse(lesson);
    }


    public async Task<PagedResult<LessonListResponse>> GetAllAsync(
     LessonQuery query)
    {
        var lessons = _context.Lessons
     .AsNoTracking()
     .AsQueryable();

        // Search by title
        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            lessons = lessons.Where(x =>
                EF.Functions.ILike(
                    x.Title,
                    $"%{query.Search}%"));
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
            lessons = lessons.Where(x =>
                x.LessonTags.Any(t =>
                    EF.Functions.ILike(t.Tag.Name, query.Tag) ||
                    EF.Functions.ILike(t.Tag.Slug, query.Tag)));
        }
        var totalCount = await lessons.CountAsync();

        var items = await lessons
            .OrderBy(x => x.DisplayOrder)
.ThenBy(x => x.Title)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new LessonListResponse
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                TopicTitle = x.Topic.Title,
                Difficulty = x.Difficulty,
                ReadingTimeMinutes = x.ReadingTimeMinutes,
                IsPublished = x.IsPublished,
                DisplayOrder = x.DisplayOrder,

                IsEmbedded = x.IsEmbedded,
                EmbeddingsGeneratedAt = x.EmbeddingsGeneratedAt
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
                TopicTitle = x.Topic.Title,
                ReadingTimeMinutes = x.ReadingTimeMinutes,
                
                DisplayOrder = x.DisplayOrder,
                IsPublished = x.IsPublished,
                IsEmbedded = x.IsEmbedded,
                EmbeddingsGeneratedAt = x.EmbeddingsGeneratedAt
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
    public async Task<LessonResponse> UpdateAsync(
     Guid id,
     UpdateLessonRequest request)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");
        var slug = GenerateSlug(request.Title);

        var slugExists = await _context.Lessons.AnyAsync(x =>
            x.Id != id &&
            x.Slug == slug);

        if (slugExists)
            throw new ConflictException("Lesson already exists.");

        var shouldRegenerate =
    lesson.Title != request.Title ||
    lesson.Summary != request.Summary ||
    lesson.Content != request.MarkdownContent;

        lesson.Title = request.Title;
        lesson.Summary = request.Summary;
        lesson.Content = request.MarkdownContent;
        lesson.Difficulty = request.Difficulty;
        lesson.ReadingTimeMinutes = request.ReadingTimeMinutes;
        lesson.IsPublished = request.IsPublished;
        lesson.Slug = slug;



        if (shouldRegenerate)
        {
            lesson.IsEmbedded = false;
            lesson.EmbeddingsGeneratedAt = null;
        }


        await _context.SaveChangesAsync();

        return MapToResponse(lesson);
    }
    public async Task DeleteAsync(Guid id)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");



        var deletedPosition = lesson.DisplayOrder;

        _context.Lessons.Remove(lesson);

        var lessonsToShift = await _context.Lessons
            .Where(x =>
                x.TopicId == lesson.TopicId &&
                x.DisplayOrder > deletedPosition)
            .ToListAsync();

        foreach (var item in lessonsToShift)
        {
            item.DisplayOrder--;
        }

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
            IsPublished = lesson.IsPublished,
            DisplayOrder = lesson.DisplayOrder,
            IsBookmarked = isBookmarked,

            IsEmbedded = lesson.IsEmbedded,
            EmbeddingsGeneratedAt = lesson.EmbeddingsGeneratedAt
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

        Lesson? neighbour = null;

        if (request.Direction == MoveDirection.Up)
        {
            neighbour = await _context.Lessons
                .Where(x =>
                    x.TopicId == lesson.TopicId &&
                    x.DisplayOrder < lesson.DisplayOrder)
                .OrderByDescending(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }
        else
        {
            neighbour = await _context.Lessons
                .Where(x =>
                    x.TopicId == lesson.TopicId &&
                    x.DisplayOrder > lesson.DisplayOrder)
                .OrderBy(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }

        if (neighbour == null)
            return;

        var temp = lesson.DisplayOrder;
        lesson.DisplayOrder = neighbour.DisplayOrder;
        neighbour.DisplayOrder = temp;

        await _context.SaveChangesAsync();
    }


}