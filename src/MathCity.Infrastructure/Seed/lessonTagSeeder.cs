using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed;

public static class LessonTagSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.LessonTags.AnyAsync())
            return;

        var lessons = await context.Lessons
            .ToDictionaryAsync(l => l.Title);

        var tags = await context.Tags
            .ToDictionaryAsync(t => t.Name);

        var lessonTags = new List<LessonTag>();

        void AddTag(string lessonTitle, string tagName)
        {
            lessonTags.Add(new LessonTag
            {
                LessonId = lessons[lessonTitle].Id,
                TagId = tags[tagName].Id
            });
        }

        // Algebraic Expressions
        // Lesson 1
        AddTag("Introduction to Algebraic Expressions", "Introduction");
        AddTag("Introduction to Algebraic Expressions", "Concept");
        AddTag("Introduction to Algebraic Expressions", "Definition");
        AddTag("Introduction to Algebraic Expressions", "Visualization");

        // Lesson 2
        AddTag("Simplifying and Evaluating Algebraic Expressions", "Formula");
        AddTag("Simplifying and Evaluating Algebraic Expressions", "Worked Example");
        AddTag("Simplifying and Evaluating Algebraic Expressions", "Step-by-Step");

        // Lesson 3
        AddTag("Applications and Practice of Algebraic Expressions", "Practice");
        AddTag("Applications and Practice of Algebraic Expressions", "Exercise");
        AddTag("Applications and Practice of Algebraic Expressions", "Application");
        AddTag("Applications and Practice of Algebraic Expressions", "Real World");
        AddTag("Applications and Practice of Algebraic Expressions", "Revision");

        context.LessonTags.AddRange(lessonTags);
        await context.SaveChangesAsync();
    }
}