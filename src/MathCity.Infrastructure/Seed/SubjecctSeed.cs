using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed;

public static class SubjectSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var subjects = new List<Subject>
        {
            new()
            {
                Name = "Mathematics",
                Slug = "mathematics",
                Description =
                    "Mathematics is the language of patterns, logic, and problem solving. From simple numbers to advanced calculus, it helps us understand how the world works and gives us the tools to solve real-life problems with confidence.",

                Icon = "math",
                Color = "#3B82F6",
                DisplayOrder = 1,
                IsPublished = true
            },

            new()
            {
                Name = "Japanese",
                Slug = "japanese",
                Description =
                    "Learn Japanese from the very beginning through vocabulary, grammar, listening, reading, writing, and speaking. Build confidence step by step while preparing for real conversations and JLPT examinations.",

                Icon = "japanese",
                Color = "#EF4444",
                DisplayOrder = 2,
                IsPublished = true
            }
        };

        foreach (var subject in subjects)
        {
            var existing = await context.Subjects
                .FirstOrDefaultAsync(x => x.Slug == subject.Slug);

            if (existing == null)
            {
                context.Subjects.Add(subject);
                continue;
            }

            existing.Name = subject.Name;
            existing.Description = subject.Description;
            existing.Icon = subject.Icon;
            existing.Color = subject.Color;
            existing.DisplayOrder = subject.DisplayOrder;
            existing.IsPublished = subject.IsPublished;
        }

        await context.SaveChangesAsync();
    }
}