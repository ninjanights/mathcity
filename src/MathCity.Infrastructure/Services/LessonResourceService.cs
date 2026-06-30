using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.LessonResources.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class LessonResourceService : ILessonResourceService
{
    private readonly ApplicationDbContext _context;

    public LessonResourceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LessonResourceResponse> CreateAsync(CreateLessonResourceRequest request)
    {
        var lessonExists = await _context.Lessons
            .AnyAsync(x => x.Id == request.LessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

        var resource = new LessonResource
        {
            LessonId = request.LessonId,
            Title = request.Title,
            Url = request.Url,
            Type = request.ResourceType,
            DisplayOrder = request.DisplayOrder
        };

        _context.LessonResources.Add(resource);

        await _context.SaveChangesAsync();

        return MapToResponse(resource);
    }

    public async Task<IReadOnlyList<LessonResourceListResponse>> GetAllAsync()
    {
        return await _context.LessonResources
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new LessonResourceListResponse
            {
                Id = x.Id,
                Title = x.Title,
                ResourceType = x.Type,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LessonResourceListResponse>> GetByLessonAsync(Guid lessonId)
    {
        return await _context.LessonResources
            .Where(x => x.LessonId == lessonId)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new LessonResourceListResponse
            {
                Id = x.Id,
                Title = x.Title,
                ResourceType = x.Type,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }

    public async Task<LessonResourceResponse> GetByIdAsync(Guid id)
    {
        var resource = await _context.LessonResources
            .FirstOrDefaultAsync(x => x.Id == id);

        if (resource == null)
            throw new NotFoundException("Lesson resource not found.");

        return MapToResponse(resource);
    }

    public async Task<LessonResourceResponse> UpdateAsync(
        Guid id,
        UpdateLessonResourceRequest request)
    {
        var resource = await _context.LessonResources
            .FirstOrDefaultAsync(x => x.Id == id);

        if (resource == null)
            throw new NotFoundException("Lesson resource not found.");

        resource.Title = request.Title;
        resource.Url = request.Url;
        resource.Type = request.ResourceType;
        resource.DisplayOrder = request.DisplayOrder;

        await _context.SaveChangesAsync();

        return MapToResponse(resource);
    }

    public async Task DeleteAsync(Guid id)
    {
        var resource = await _context.LessonResources
            .FirstOrDefaultAsync(x => x.Id == id);

        if (resource == null)
            throw new NotFoundException("Lesson resource not found.");

        _context.LessonResources.Remove(resource);

        await _context.SaveChangesAsync();
    }

    private static LessonResourceResponse MapToResponse(LessonResource resource)
    {
        return new LessonResourceResponse
        {
            Id = resource.Id,
            LessonId = resource.LessonId,
            Title = resource.Title,
            Url = resource.Url,
            ResourceType = resource.Type,
            DisplayOrder = resource.DisplayOrder
        };
    }
}