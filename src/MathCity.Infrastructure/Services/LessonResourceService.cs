using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.LessonResources.Interfaces;
using MathCity.Application.Features.Storage.DTOs;
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

    public async Task<LessonResourceResponse> CreateAsync(
    CreateLessonResourceRequest request,
    FileUploadResponse upload)
    {
        var lessonExists = await _context.Lessons
            .AnyAsync(x => x.Id == request.LessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

        await MoveDisplayOrderAsync(
    request.LessonId,
    request.DisplayOrder);


        var resource = new LessonResource
        {
            LessonId = request.LessonId,
            Title = request.Title,
            
            FileName = upload.FileName,
            FilePath = upload.FilePath,
            FileUrl = upload.PublicUrl,
            FileSize = upload.Size,
            ContentType = upload.ContentType,
            Description = request.Description,
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
                Description = x.Description,
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
                Description = x.Description,
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

        if (resource.DisplayOrder != request.DisplayOrder)
        {
            await MoveDisplayOrderAsync(
                resource.LessonId,
                request.DisplayOrder,
                resource.Id);
        }

        resource.Title = request.Title;
        resource.Description = request.Description;
        resource.Type = request.ResourceType;
        resource.DisplayOrder = request.DisplayOrder;

        await _context.SaveChangesAsync();

        return MapToResponse(resource);
    }


    public async Task MoveAsync(
    Guid id,
    MoveLessonResourceRequest request)
{
    var resource = await _context.LessonResources
        .FirstOrDefaultAsync(x => x.Id == id);

    if (resource == null)
        throw new NotFoundException("Lesson resource not found.");

    await MoveDisplayOrderAsync(
        resource.LessonId,
        request.Position,
        resource.Id);
}


    private async Task MoveDisplayOrderAsync(
    Guid lessonId,
    int newPosition,
    Guid? resourceId = null)
    {
        var resources = await _context.LessonResources
            .Where(x => x.LessonId == lessonId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        LessonResource? moving = null;

        if (resourceId.HasValue)
        {
            moving = resources.First(x => x.Id == resourceId.Value);
            resources.Remove(moving);
        }

        newPosition = Math.Clamp(newPosition, 1, resources.Count + 1);

        if (moving != null)
        {
            resources.Insert(newPosition - 1, moving);
        }

        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].DisplayOrder = i + 1000;
        }

        await _context.SaveChangesAsync();

        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].DisplayOrder = i + 1;
        }

        await _context.SaveChangesAsync();
    }



    public async Task DeleteAsync(Guid id)
    {
        var resource = await _context.LessonResources
            .FirstOrDefaultAsync(x => x.Id == id);

        if (resource == null)
            throw new NotFoundException("Lesson resource not found.");

        _context.LessonResources.Remove(resource);

        await _context.SaveChangesAsync();

        var resources = await _context.LessonResources
            .Where(x => x.LessonId == resource.LessonId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].DisplayOrder = i + 1;
        }

        await _context.SaveChangesAsync();
    }

    private static LessonResourceResponse MapToResponse(LessonResource resource)
    {
        return new LessonResourceResponse
        {
            Id = resource.Id,
            LessonId = resource.LessonId,
            Title = resource.Title,
            ResourceType = resource.Type,
            Description = resource.Description,
            DisplayOrder = resource.DisplayOrder
        };
    }
}