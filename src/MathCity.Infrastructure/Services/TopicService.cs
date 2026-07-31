using MathCity.Application.Common.Exceptions;
using MathCity.Application.Common.Models;
using MathCity.Application.Features.Topics.DTOs;
using MathCity.Application.Features.Topics.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class TopicService : ITopicService
{
    private readonly ApplicationDbContext _context;

    public TopicService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TopicResponse> CreateAsync(CreateTopicRequest request)
    {
        var chapterExists = await _context.Chapters
            .AnyAsync(x => x.Id == request.ChapterId);

        if (!chapterExists)
        {
            throw new NotFoundException("Chapter not found.");
        }

        var maxDisplayOrder = await _context.Topics
            .Where(x => x.ChapterId == request.ChapterId)
            .Select(x => (int?)x.DisplayOrder)
            .MaxAsync() ?? 0;

        var topic = new Topic
        {
            ChapterId = request.ChapterId,
            Title = request.Title,
            DisplayOrder = maxDisplayOrder + 1
        };

        _context.Topics.Add(topic);

        await _context.SaveChangesAsync();

        return MapToResponse(topic);
    }

    // move scoped topic
    public async Task MoveAsync(
      Guid id,
      MoveTopicRequest request)
    {
        var topic = await _context.Topics
            .FirstOrDefaultAsync(x => x.Id == id);

        if (topic == null)
            throw new NotFoundException("Topic not found.");

        Topic? neighbour = null;

        if (request.Direction == MoveDirection.Up)
        {
            neighbour = await _context.Topics
                .Where(x =>
                    x.ChapterId == topic.ChapterId &&
                    x.DisplayOrder < topic.DisplayOrder)
                .OrderByDescending(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }
        else
        {
            neighbour = await _context.Topics
                .Where(x =>
                    x.ChapterId == topic.ChapterId &&
                    x.DisplayOrder > topic.DisplayOrder)
                .OrderBy(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }

        if (neighbour == null)
            return;

        var temp = topic.DisplayOrder;
        topic.DisplayOrder = neighbour.DisplayOrder;
        neighbour.DisplayOrder = temp;

        await _context.SaveChangesAsync();
    }


    public async Task<PagedResult<TopicListResponse>> GetAllAsync(
    TopicQuery query)
    {
        var topics = _context.Topics.AsQueryable();

        // Search
        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            topics = topics.Where(x =>
                EF.Functions.ILike(
                    x.Title,
                    $"%{query.Search}%"));
        }

        // Filter by Chapter
        if (query.ChapterId.HasValue)
        {
            topics = topics.Where(x =>
                x.ChapterId == query.ChapterId.Value);
        }

        var totalCount = await topics.CountAsync();

        var items = await topics
            .OrderBy(x => x.DisplayOrder)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new TopicListResponse
            {
                Id = x.Id,
                ChapterId = x.ChapterId,
                Title = x.Title,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();

        return new PagedResult<TopicListResponse>
        {
            Items = items,
            Page = query.Page,
            PageSize = query.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)query.PageSize)
        };
    }














    public async Task<IReadOnlyList<TopicListResponse>> GetByChapterAsync(Guid chapterId)
    {
        var chapterExists = await _context.Chapters
            .AnyAsync(x => x.Id == chapterId);

        if (!chapterExists)
        {
            throw new NotFoundException("Chapter not found.");
        }

        return await _context.Topics
            .Where(x => x.ChapterId == chapterId)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new TopicListResponse
            {
                Id = x.Id,
                ChapterId = x.ChapterId,
                Title = x.Title,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }

    public async Task<TopicResponse> GetByIdAsync(Guid id)
    {
        var topic = await _context.Topics
            .FirstOrDefaultAsync(x => x.Id == id);

        if (topic is null)
        {
            throw new NotFoundException("Topic not found.");
        }

        return MapToResponse(topic);
    }

    public async Task<TopicResponse> UpdateAsync(
        Guid id,
        UpdateTopicRequest request)
    {
        var topic = await _context.Topics
            .FirstOrDefaultAsync(x => x.Id == id);

        if (topic is null)
        {
            throw new NotFoundException("Topic not found.");
        }

        topic.Title = request.Title;

        await _context.SaveChangesAsync();

       

        return MapToResponse(topic);
    }

    public async Task DeleteAsync(Guid id)
    {
        var topic = await _context.Topics
            .FirstOrDefaultAsync(x => x.Id == id);

        if (topic is null)
        {
            throw new NotFoundException("Topic not found.");
        }

        var deletedPosition = topic.DisplayOrder;

        _context.Topics.Remove(topic);

        var topicsToShift = await _context.Topics
            .Where(x =>
                x.ChapterId == topic.ChapterId &&
                x.DisplayOrder > deletedPosition)
            .ToListAsync();

        foreach (var item in topicsToShift)
        {
            item.DisplayOrder--;
        }

        await _context.SaveChangesAsync();
    }

    private static TopicResponse MapToResponse(Topic topic)
    {
        return new TopicResponse
        {
            Id = topic.Id,
            ChapterId = topic.ChapterId,
            Title = topic.Title,
            DisplayOrder = topic.DisplayOrder
        };
    }
}