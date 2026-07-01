using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Subjects.DTOs;
using MathCity.Application.Features.Subjects.Interfaces;
using MathCity.Domain.Entities;
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

        var subject = new Subject
        {
            Name = request.Name,
            Slug = slug,
            Description = request.Description,
            Icon = request.Icon,
            Color = request.Color,
            DisplayOrder = request.DisplayOrder,
            IsPublished = true
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

        _context.Subjects.Remove(subject);

        await _context.SaveChangesAsync();
    }

    // Implement the GetAllAsync method to retrieve all subjects
    public async Task<IReadOnlyList<SubjectListResponse>> GetAllAsync(
      string? search = null)
    {
        var query = _context.Subjects.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                EF.Functions.ILike(
                    x.Name,
                    $"%{search}%"));
        }

        return await query
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new SubjectListResponse
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Icon = x.Icon,
                Color = x.Color
            })
            .ToListAsync();
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

        subject.Name = request.Name;
        subject.Slug = GenerateSlug(request.Name);
        subject.Description = request.Description;
        subject.Icon = request.Icon;
        subject.Color = request.Color;
        subject.DisplayOrder = request.DisplayOrder;
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