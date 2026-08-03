using MathCity.Application.Common.Exceptions;
using MathCity.Application.Common.Models;
using MathCity.Application.Features.Chapters.DTOs;
using MathCity.Application.Features.Subjects.DTOs;
using MathCity.Application.Features.Subjects.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Services;

public class SubjectService : ISubjectService
{
    private readonly ApplicationDbContext _context;

    public SubjectService(ApplicationDbContext context)
    {
        _context = context;
    }
    // Implement the CreateAsync method to create a new subject
    public async Task<SubjectResponse> CreateAsync(CreateSubjectRequest request)
    {
        var slug = GenerateSlug(request.Name);

        var exists = await _context.Subjects
            .AnyAsync(x => x.Slug == slug);

        if (exists)
        {
            throw new ConflictException("A subject with this name already exists.");
        }
        var maxDisplayOrder = await _context.Subjects
    .Select(x => (int?)x.DisplayOrder)
    .MaxAsync() ?? 0;

        var subject = new Subject
        {
            Name = request.Name,
            Slug = slug,
            Description = request.Description,
            Icon = request.Icon,
            Color = request.Color,
            DisplayOrder = maxDisplayOrder + 1,
            IsPublished = false

        };

        _context.Subjects.Add(subject);

        await _context.SaveChangesAsync();

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            Slug = subject.Slug,
            Description = subject.Description,
            Icon = subject.Icon,
            Color = subject.Color,
            DisplayOrder = subject.DisplayOrder,
            IsPublished = subject.IsPublished
        };
    }

    // Implement the DeleteAsync method to delete a subject by its ID
    public async Task DeleteAsync(Guid id)
    {
        var subject = await _context.Subjects
            .FirstOrDefaultAsync(x => x.Id == id);

        if (subject == null)
        {
            throw new NotFoundException("Subject not found.");
        }

        var deletedOrder = subject.DisplayOrder;

        _context.Subjects.Remove(subject);

        var subjectsToShift = await _context.Subjects
            .Where(x => x.DisplayOrder > deletedOrder)
            .ToListAsync();

        foreach (var item in subjectsToShift)
        {
            item.DisplayOrder--;
        }

        await _context.SaveChangesAsync();
    }

    // Implement the GetAllAsync method to retrieve all subjects
    public async Task<PagedResult<SubjectListResponse>> GetAllAsync(
      SubjectQuery query)
    {
        var subjects = _context.Subjects.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            subjects = subjects.Where(x =>
                EF.Functions.ILike(
                    x.Name,
                    $"%{query.Search}%"));
        }

        var totalCount = await subjects.CountAsync();

        var items = await subjects
            .OrderBy(x => x.DisplayOrder)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new SubjectListResponse
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Icon = x.Icon,
                Color = x.Color,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder,
                IsPublished = x.IsPublished,

                ChapterCount = x.Chapters.Count(),

                TopicCount = x.Chapters
                    .SelectMany(c => c.Topics)
                    .Count(),

                LessonCount = x.Chapters
                    .SelectMany(c => c.Topics)
                    .SelectMany(t => t.Lessons)
                    .Count(),

                LessonResourceCount = x.Chapters
                    .SelectMany(c => c.Topics)
                    .SelectMany(t => t.Lessons)
                    .SelectMany(l => l.Resources)
                    .Count(),

                PracticeQuestionCount = x.Chapters
                    .SelectMany(c => c.Topics)
                    .SelectMany(t => t.Lessons)
                    .SelectMany(l => l.PracticeQuestions)
                    .Count()
            })
            .ToListAsync();

        return new PagedResult<SubjectListResponse>
        {
            Items = items,
            Page = query.Page,
            PageSize = query.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)query.PageSize)
        };
    }


    // Implement the GetByIdAsync method to retrieve a subject by its ID
    public async Task<SubjectResponse> GetByIdAsync(Guid id)
    {
        var subject = await _context.Subjects
            .FirstOrDefaultAsync(x => x.Id == id);

        if (subject == null)
        {
            throw new NotFoundException("Subject not found.");
        }

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            Slug = subject.Slug,
            Description = subject.Description,
            Icon = subject.Icon,
            Color = subject.Color,
            DisplayOrder = subject.DisplayOrder,
            IsPublished = subject.IsPublished
        };
    }

    public async Task MoveAsync(
        Guid id,
        MoveSubjectRequest request)
    {
        var subject = await _context.Subjects
            .FirstOrDefaultAsync(x => x.Id == id);

        if (subject == null)
            throw new NotFoundException("Subject not found.");

        Subject? neighbour = null;

        if (request.Direction == MoveDirection.Up)
        {
            neighbour = await _context.Subjects
                .Where(x => x.DisplayOrder < subject.DisplayOrder)
                .OrderByDescending(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }
        else
        {
            neighbour = await _context.Subjects
                .Where(x => x.DisplayOrder > subject.DisplayOrder)
                .OrderBy(x => x.DisplayOrder)
                .FirstOrDefaultAsync();
        }

        // Already at the top/bottom
        if (neighbour == null)
            return;

        var temp = subject.DisplayOrder;
        subject.DisplayOrder = neighbour.DisplayOrder;
        neighbour.DisplayOrder = temp;

        await _context.SaveChangesAsync();
    }

    // Implement the UpdateAsync method to update an existing subject
    public async Task<SubjectResponse> UpdateAsync(
     Guid id,
     UpdateSubjectRequest request)
    {
        var subject = await _context.Subjects
            .FirstOrDefaultAsync(x => x.Id == id);

        if (subject == null)
        {
            throw new NotFoundException("Subject not found.");
        }
        var slug = GenerateSlug(request.Name);

        var exists = await _context.Subjects.AnyAsync(x =>
            x.Id != id &&
            x.Slug == slug);

        if (exists)
        {
            throw new ConflictException("A subject with this name already exists.");
        }

        subject.Name = request.Name;
        subject.Slug = slug;
        subject.Description = request.Description;
        subject.Icon = request.Icon;
        subject.Color = request.Color;
        subject.IsPublished = request.IsPublished;

        await _context.SaveChangesAsync();

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            Slug = subject.Slug,
            Description = subject.Description,
            Icon = subject.Icon,
            Color = subject.Color,
            DisplayOrder = subject.DisplayOrder,
            IsPublished = subject.IsPublished
        };
    }

    private static string GenerateSlug(string text)
    {
        return text
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    }

}