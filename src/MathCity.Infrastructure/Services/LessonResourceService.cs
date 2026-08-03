using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.LessonResources.Interfaces;
using MathCity.Application.Features.Storage.DTOs;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MathCity.Application.Common.Models;
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

        var maxDisplayOrder = await _context.LessonResources
            .Where(x => x.LessonId == request.LessonId)
            .Select(x => (int?)x.DisplayOrder)
            .MaxAsync() ?? 0;

        var resource = new LessonResource
        {
            LessonId = request.LessonId,
            Title = request.Title,
            
            FileName = upload.FileName,
           
            FileUrl = upload.PublicUrl,
            FileSize = upload.Size,
            ContentType = upload.ContentType,
            Description = request.Description,
            Type = request.ResourceType,
            DisplayOrder = maxDisplayOrder +1,
        };

        _context.LessonResources.Add(resource);

        await _context.SaveChangesAsync();

        return MapToResponse(resource);
    }

    public async Task<PagedResult<LessonResourceListResponse>> GetAllAsync(
     LessonResourceQuery query)
    {
        var resources = _context.LessonResources
            .AsNoTracking()
            .AsQueryable();


        if (!string.IsNullOrWhiteSpace(query.LessonSlug))
        {
            var lessonId = await _context.Lessons
                .Where(x => x.Slug == query.LessonSlug)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (lessonId == Guid.Empty)
                throw new NotFoundException("Lesson not found.");


            resources = resources
                .Where(x => x.LessonId == lessonId);
        }


        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            resources = resources.Where(x =>
                x.Title.Contains(query.Search) ||
               (x.Description != null &&
     x.Description.Contains(query.Search)));
        }


        if (query.ResourceType.HasValue)
        {
            resources = resources.Where(x =>
                x.Type == query.ResourceType.Value);
        }


        var totalCount = await resources.CountAsync();


        var items = await resources
            .OrderBy(x => x.DisplayOrder)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new LessonResourceListResponse
            {
                Id = x.Id,
                Title = x.Title,
                ResourceType = x.Type,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();


        return new PagedResult<LessonResourceListResponse>
        {
            Items = items,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
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


        resource.Title = request.Title;
        resource.Description = request.Description;
        resource.Type = request.ResourceType;

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

        LessonResource? neighbour = null;

        if (request.Direction == MoveDirection.Up)
        {
            neighbour = await _context.LessonResources
                .Where(x =>
                    x.LessonId == resource.LessonId &&
                    x.DisplayOrder < resource.DisplayOrder)
                .OrderByDescending(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }
        else
        {
            neighbour = await _context.LessonResources
                .Where(x =>
                    x.LessonId == resource.LessonId &&
                    x.DisplayOrder > resource.DisplayOrder)
                .OrderBy(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }

        if (neighbour == null)
            return;

        var temp = resource.DisplayOrder;
        resource.DisplayOrder = neighbour.DisplayOrder;
        neighbour.DisplayOrder = temp;

        await _context.SaveChangesAsync();
    }




    public async Task DeleteAsync(Guid id)
    {
        var resource = await _context.LessonResources
            .FirstOrDefaultAsync(x => x.Id == id);

        if (resource == null)
            throw new NotFoundException("Lesson resource not found.");

        var deletedPosition = resource.DisplayOrder;

        _context.LessonResources.Remove(resource);

        var resourcesToShift = await _context.LessonResources
            .Where(x =>
                x.LessonId == resource.LessonId &&
                x.DisplayOrder > deletedPosition)
            .ToListAsync();

        foreach (var item in resourcesToShift)
        {
            item.DisplayOrder--;
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
            Url = resource.FileUrl,
            FileSize = resource.FileSize,
            Description = resource.Description,
            DisplayOrder = resource.DisplayOrder
        };
    }
}


    //public Guid LessonId { get; set; }

    //public Lesson Lesson { get; set; } = null!;

    //public string Title { get; set; } = string.Empty;

    //public string FileName { get; set; } = string.Empty;

    //public string? Description { get; set; }

    //public string FileUrl { get; set; } = string.Empty;

    //public long FileSize { get; set; }

    //public string ContentType { get; set; } = string.Empty;

    //public ResourceType Type { get; set; }

    //public int DisplayOrder { get; set; }