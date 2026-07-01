using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.LessonTags.DTOs;
using MathCity.Application.Features.LessonTags.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class LessonTagService : ILessonTagService
{
    private readonly ApplicationDbContext _context;

    public LessonTagService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LessonTagResponse> CreateAsync(
        Guid lessonId,
        CreateLessonTagRequest request)
    {
        var lesson = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == lessonId);

        if (lesson == null)
            throw new NotFoundException("Lesson not found.");

        var tag = await _context.Tags
            .FirstOrDefaultAsync(x => x.Id == request.TagId);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        var exists = await _context.LessonTags
            .AnyAsync(x =>
                x.LessonId == lessonId &&
                x.TagId == request.TagId);

        if (exists)
            throw new ConflictException("Tag already attached to this lesson.");

        var lessonTag = new LessonTag
        {
            LessonId = lessonId,
            TagId = request.TagId
        };

        _context.LessonTags.Add(lessonTag);

        await _context.SaveChangesAsync();

        return new LessonTagResponse
        {
            LessonId = lessonId,
            TagId = tag.Id,
            TagName = tag.Name,
            TagSlug = tag.Slug
        };
    }

    public async Task<IReadOnlyList<LessonTagResponse>> GetByLessonAsync(
        Guid lessonId)
    {
        var lessonExists = await _context.Lessons
            .AnyAsync(x => x.Id == lessonId);

        if (!lessonExists)
            throw new NotFoundException("Lesson not found.");

        return await _context.LessonTags
            .Where(x => x.LessonId == lessonId)
            .Include(x => x.Tag)
            .OrderBy(x => x.Tag.Name)
            .Select(x => new LessonTagResponse
            {
                LessonId = x.LessonId,
                TagId = x.TagId,
                TagName = x.Tag.Name,
                TagSlug = x.Tag.Slug
            })
            .ToListAsync();
    }

    public async Task DeleteAsync(
        Guid lessonId,
        Guid tagId)
    {
        var lessonTag = await _context.LessonTags
            .FirstOrDefaultAsync(x =>
                x.LessonId == lessonId &&
                x.TagId == tagId);

        if (lessonTag == null)
            throw new NotFoundException("Lesson tag not found.");

        _context.LessonTags.Remove(lessonTag);

        await _context.SaveChangesAsync();
    }
}