using MathCity.Application.Common.Exceptions;
using MathCity.Application.Common.Models;
using MathCity.Application.Features.Tags.DTOs;
using MathCity.Application.Features.Tags.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class TagService : ITagService
{
    private readonly ApplicationDbContext _context;

    public TagService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TagResponse> CreateAsync(CreateTagRequest request)
    {
        var slug = GenerateSlug(request.Name);

        var exists = await _context.Tags.AnyAsync(x =>
            x.Name == request.Name ||
            x.Slug == slug);

        if (exists)
            throw new ConflictException("Tag already exists.");

        var tag = new Tag
        {
            Name = request.Name,
            Slug = slug
        };

        _context.Tags.Add(tag);

        await _context.SaveChangesAsync();

        return MapToResponse(tag);
    }

    // Get all tags with optional search
    public async Task<PagedResult<TagListResponse>> GetAllAsync(
     TagQuery query)
    {
        var tags = _context.Tags
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            tags = tags.Where(x =>
                EF.Functions.ILike(
                    x.Name,
                    $"%{query.Search}%"));
        }

        var totalCount = await tags.CountAsync();

        var items = await tags
            .OrderBy(x => x.Name)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new TagListResponse
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug
            })
            .ToListAsync();

        return new PagedResult<TagListResponse>
        {
            Items = items,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
    }

    public async Task<TagResponse> GetByIdAsync(Guid id)
    {
        var tag = await _context.Tags
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        return MapToResponse(tag);
    }

    public async Task<TagResponse> UpdateAsync(
        Guid id,
        UpdateTagRequest request)
    {
        var tag = await _context.Tags
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        var slug = GenerateSlug(request.Name);

        var exists = await _context.Tags.AnyAsync(x =>
            x.Id != id &&
            (x.Name == request.Name || x.Slug == slug));

        if (exists)
            throw new ConflictException("Tag already exists.");

        tag.Name = request.Name;
        tag.Slug = slug;

        await _context.SaveChangesAsync();

        return MapToResponse(tag);
    }

    public async Task DeleteAsync(Guid id)
    {
        var tag = await _context.Tags
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        _context.Tags.Remove(tag);

        await _context.SaveChangesAsync();
    }

    private static TagResponse MapToResponse(Tag tag)
    {
        return new TagResponse
        {
            Id = tag.Id,
            Name = tag.Name,
            Slug = tag.Slug
        };
    }

    private static string GenerateSlug(string name)
    {
        return name.Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    }
}