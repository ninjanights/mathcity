using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Topics.DTOs;
using MathCity.Application.Features.Topics.Interfaces;
using MathCity.Domain.Entities;
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

        var topic = new Topic
        {
            ChapterId = request.ChapterId,
            Title = request.Title,
            DisplayOrder = request.DisplayOrder
        };

        _context.Topics.Add(topic);

        await _context.SaveChangesAsync();

        return MapToResponse(topic);
    }

    public async Task<IReadOnlyList<TopicListResponse>> GetAllAsync()
    {
        return await _context.Topics
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
        topic.DisplayOrder = request.DisplayOrder;

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

        _context.Topics.Remove(topic);

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