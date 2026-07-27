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
            if (!lessons.TryGetValue(lessonTitle, out var lesson))
                return;

            if (!tags.TryGetValue(tagName, out var tag))
                return;

            lessonTags.Add(new LessonTag
            {
                LessonId = lesson.Id,
                TagId = tag.Id
            });
        }
        // Algebraic Expressions 1
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

        // Geometry 2
        AddTag("Introduction to Triangles", "Introduction");
        AddTag("Introduction to Triangles", "Concept");
        AddTag("Introduction to Triangles", "Definition");
        AddTag("Introduction to Triangles", "Visualization");

        AddTag("Types of Triangles", "Concept");
        AddTag("Types of Triangles", "Formula");
        AddTag("Types of Triangles", "Worked Example");
        AddTag("Types of Triangles", "Step-by-Step");

        AddTag("Applications of Triangles", "Application");
        AddTag("Applications of Triangles", "Practice");
        AddTag("Applications of Triangles", "Real World");
        AddTag("Applications of Triangles", "Revision");


        // Coordinate Geometry 3
        AddTag("Introduction to Cartesian Plane", "Introduction");
        AddTag("Introduction to Cartesian Plane", "Concept");
        AddTag("Introduction to Cartesian Plane", "Definition");
        AddTag("Introduction to Cartesian Plane", "Visualization");

        AddTag("Understanding Coordinates and Quadrants", "Concept");
        AddTag("Understanding Coordinates and Quadrants", "Visualization");
        AddTag("Understanding Coordinates and Quadrants", "Worked Example");
        AddTag("Understanding Coordinates and Quadrants", "Step-by-Step");

        AddTag("Applications and Practice of Cartesian Plane", "Practice");
        AddTag("Applications and Practice of Cartesian Plane", "Exercise");
        AddTag("Applications and Practice of Cartesian Plane", "Application");
        AddTag("Applications and Practice of Cartesian Plane", "Real World");
        AddTag("Applications and Practice of Cartesian Plane", "Revision");



        context.LessonTags.AddRange(lessonTags);
        await context.SaveChangesAsync();
    }
}