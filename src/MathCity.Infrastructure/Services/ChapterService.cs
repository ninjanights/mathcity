using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Chapters.DTOs;
using MathCity.Application.Features.Chapters.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MathCity.Domain.Enums;

namespace MathCity.Infrastructure.Services;

public class ChapterService : IChapterService
{
    private readonly ApplicationDbContext _context;

    public ChapterService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ChapterResponse> CreateAsync(CreateChapterRequest request)
    {
        var subjectExists = await _context.Subjects
            .AnyAsync(x => x.Id == request.SubjectId);

        if (!subjectExists)
        {
            throw new NotFoundException("Subject not found.");
        }

        var chapter = new Chapter
        {
            SubjectId = request.SubjectId,
            Title = request.Title,
            Description = request.Description,
            DisplayOrder = request.DisplayOrder
        };

        _context.Chapters.Add(chapter);

        await _context.SaveChangesAsync();

        return MapToResponse(chapter);
    }

    public async Task<IReadOnlyList<ChapterListResponse>> GetAllAsync(
      string? search = null)
    {
        var query = _context.Chapters.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                EF.Functions.ILike(
                    x.Title,
                    $"%{search}%"));
        }

        return await query
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new ChapterListResponse
            {
                Id = x.Id,
                SubjectId = x.SubjectId,
                Title = x.Title,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }


    public async Task<IReadOnlyList<ChapterListResponse>> GetBySubjectAsync(Guid subjectId)
    {
        var subjectExists = await _context.Subjects
            .AnyAsync(x => x.Id == subjectId);

        if (!subjectExists)
        {
            throw new NotFoundException("Subject not found.");
        }

        return await _context.Chapters
            .Where(x => x.SubjectId == subjectId)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new ChapterListResponse
            {
                Id = x.Id,
                SubjectId = x.SubjectId,
                Title = x.Title,
                DisplayOrder = x.DisplayOrder
            })
            .ToListAsync();
    }


    public async Task<ChapterResponse> GetByIdAsync(Guid id)
    {
        var chapter = await _context.Chapters
            .FirstOrDefaultAsync(x => x.Id == id);

        if (chapter is null)
        {
            throw new NotFoundException("Chapter not found.");
        }

        return MapToResponse(chapter);
    }

    public async Task<ChapterResponse> UpdateAsync(
        Guid id,
        UpdateChapterRequest request)
    {
        var chapter = await _context.Chapters
            .FirstOrDefaultAsync(x => x.Id == id);

        if (chapter is null)
        {
            throw new NotFoundException("Chapter not found.");
        }

        chapter.Title = request.Title;
        chapter.Description = request.Description;
        chapter.DisplayOrder = request.DisplayOrder;

        await _context.SaveChangesAsync();

        return MapToResponse(chapter);
    }

    public async Task DeleteAsync(Guid id)
    {
        var chapter = await _context.Chapters
            .FirstOrDefaultAsync(x => x.Id == id);

        if (chapter is null)
        {
            throw new NotFoundException("Chapter not found.");
        }

        _context.Chapters.Remove(chapter);

        await _context.SaveChangesAsync();
    }

    private static ChapterResponse MapToResponse(Chapter chapter)
    {
        return new ChapterResponse
        {
            Id = chapter.Id,
            SubjectId = chapter.SubjectId,
            Title = chapter.Title,
            Description = chapter.Description,
            DisplayOrder = chapter.DisplayOrder
        };
    }
}