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

        // Total chapters inside this subject
        var total = await _context.Chapters
            .CountAsync(x => x.SubjectId == request.SubjectId);

        // Clamp position
        var newPosition = Math.Max(
            1,
            Math.Min(request.DisplayOrder, total + 1));

        // Shift all chapters at or after this position
        var chaptersToShift = await _context.Chapters
            .Where(x =>
                x.SubjectId == request.SubjectId &&
                x.DisplayOrder >= newPosition)
            .ToListAsync();

        foreach (var chapter in chaptersToShift)
        {
            chapter.DisplayOrder++;
        }

        var chapterEntity = new Chapter
        {
            SubjectId = request.SubjectId,
            Title = request.Title,
            Description = request.Description,
            DisplayOrder = newPosition
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

        var totalChapters = await _context.Chapters
            .CountAsync(x => x.SubjectId == chapter.SubjectId);

        var newPosition = Math.Max(
            1,
            Math.Min(request.Position, totalChapters));

        var oldPosition = chapter.DisplayOrder;

        if (oldPosition == newPosition)
            return;

        if (newPosition < oldPosition)
        {
            // Moving upward
            var chaptersToShift = await _context.Chapters
                .Where(x =>
                    x.SubjectId == chapter.SubjectId &&
                    x.DisplayOrder >= newPosition &&
                    x.DisplayOrder < oldPosition)
                .ToListAsync();

            foreach (var item in chaptersToShift)
            {
                item.DisplayOrder++;
            }
        }
        else
        {
            // Moving downward
            var chaptersToShift = await _context.Chapters
                .Where(x =>
                    x.SubjectId == chapter.SubjectId &&
                    x.DisplayOrder <= newPosition &&
                    x.DisplayOrder > oldPosition)
                .ToListAsync();

            foreach (var item in chaptersToShift)
            {
                item.DisplayOrder--;
            }
        }

        chapter.DisplayOrder = newPosition;

        await _context.SaveChangesAsync();
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

        if (chapter.DisplayOrder != request.DisplayOrder)
        {
            await MoveAsync(
                id,
                new MoveChapterRequest
                {
                    Position = request.DisplayOrder
                });

            chapter = await _context.Chapters
                .FirstAsync(x => x.Id == id);
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