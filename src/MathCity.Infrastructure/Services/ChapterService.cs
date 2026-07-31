using MathCity.Application.Common.Exceptions;
using MathCity.Application.Common.Models;
using MathCity.Application.Features.Chapters.DTOs;
using MathCity.Application.Features.Chapters.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        var maxDisplayOrder = await _context.Chapters
      .Where(x => x.SubjectId == request.SubjectId)
      .Select(x => (int?)x.DisplayOrder)
      .MaxAsync() ?? 0;

        var chapterEntity = new Chapter
        {
            SubjectId = request.SubjectId,
            Title = request.Title,
            Description = request.Description,
            DisplayOrder = maxDisplayOrder + 1
        };


        _context.Chapters.Add(chapterEntity);

        await _context.SaveChangesAsync();

        return MapToResponse(chapterEntity);
    }



    public async Task MoveAsync(
       Guid id,
       MoveChapterRequest request)
    {
        var chapter = await _context.Chapters
            .FirstOrDefaultAsync(x => x.Id == id);

        if (chapter == null)
            throw new NotFoundException("Chapter not found.");

        Chapter? neighbour = null;

        if (request.Direction == MoveDirection.Up)
        {
            neighbour = await _context.Chapters
                .Where(x =>
                    x.SubjectId == chapter.SubjectId &&
                    x.DisplayOrder < chapter.DisplayOrder)
                .OrderByDescending(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }
        else
        {
            neighbour = await _context.Chapters
                .Where(x =>
                    x.SubjectId == chapter.SubjectId &&
                    x.DisplayOrder > chapter.DisplayOrder)
                .OrderBy(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }

        if (neighbour == null)
            return;

        var temp = chapter.DisplayOrder;
        chapter.DisplayOrder = neighbour.DisplayOrder;
        neighbour.DisplayOrder = temp;

        await _context.SaveChangesAsync();
    }



    public async Task<PagedResult<ChapterListResponse>> GetAllAsync(
        ChapterQuery query)
    {
        var chapters = _context.Chapters.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            chapters = chapters.Where(x =>
                EF.Functions.ILike(
                    x.Title,
                    $"%{query.Search}%"));
        }


        if (!string.IsNullOrWhiteSpace(query.SubjectSlug))
        {
            chapters = chapters.Where(x =>
                x.Subject.Slug == query.SubjectSlug);
        }
        var totalCount = await chapters.CountAsync();

        var items = await chapters
    .OrderBy(x => x.DisplayOrder)
    .Skip((query.Page - 1) * query.PageSize)
    .Take(query.PageSize)
    .Select(x => new ChapterListResponse
    {
        Id = x.Id,
        SubjectId = x.SubjectId,
        Title = x.Title,
        DisplayOrder = x.DisplayOrder
    })
    .ToListAsync();

        return new PagedResult<ChapterListResponse>
        {
            Items = items,
            Page = query.Page,
            PageSize = query.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)query.PageSize)
        };
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

        await _context.SaveChangesAsync();

        return MapToResponse(chapter);
    }

    public async Task DeleteAsync(Guid id)
    {
        var chapter = await _context.Chapters
            .FirstOrDefaultAsync(x => x.Id == id);

        if (chapter == null)
            throw new NotFoundException("Chapter not found.");

        var deletedPosition = chapter.DisplayOrder;

        _context.Chapters.Remove(chapter);

        var chaptersToShift = await _context.Chapters
            .Where(x =>
                x.SubjectId == chapter.SubjectId &&
                x.DisplayOrder > deletedPosition)
            .ToListAsync();

        foreach (var item in chaptersToShift)
        {
            item.DisplayOrder--;
        }

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