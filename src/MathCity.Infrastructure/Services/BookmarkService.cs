using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Bookmarks.DTOs;
using MathCity.Application.Features.Bookmarks.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class BookmarkService : IBookmarkService
{
    private readonly ApplicationDbContext _context;

    public BookmarkService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookmarkResponse> CreateAsync(
        Guid userId,
        CreateBookmarkRequest request)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == request.LessonId);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        var exists = await _context.Bookmarks
            .AnyAsync(x =>
                x.UserId == userId &&
                x.LessonId == request.LessonId);

        if (exists)
            throw new ConflictException("Lesson already bookmarked.");

        var bookmark = new Bookmark
        {
            UserId = userId,
            LessonId = request.LessonId
        };

        _context.Bookmarks.Add(bookmark);

        await _context.SaveChangesAsync();

        return new BookmarkResponse
        {
            Id = bookmark.Id,
            LessonId = lesson.Id,
            LessonTitle = lesson.Title,
            LessonSlug = lesson.Slug
        };
    }

    public async Task<IReadOnlyList<BookmarkListResponse>> GetByUserAsync(
        Guid userId)
    {
        return await _context.Bookmarks
            .Where(x => x.UserId == userId)
            .Include(x => x.Lesson)
            .OrderBy(x => x.Lesson.Title)
            .Select(x => new BookmarkListResponse
            {
                Id = x.Id,
                LessonId = x.LessonId,
                LessonTitle = x.Lesson.Title,
                LessonSlug = x.Lesson.Slug
            })
            .ToListAsync();
    }

    public async Task DeleteAsync(
        Guid userId,
        Guid bookmarkId)
    {
        var bookmark = await _context.Bookmarks
            .FirstOrDefaultAsync(x =>
                x.Id == bookmarkId &&
                x.UserId == userId);

        if (bookmark == null)
            throw new NotFoundException("Bookmark not found.");

        _context.Bookmarks.Remove(bookmark);

        await _context.SaveChangesAsync();
    }
}
