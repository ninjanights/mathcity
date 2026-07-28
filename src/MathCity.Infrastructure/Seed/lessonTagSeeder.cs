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

        var lessons = await context.Lessons.ToListAsync();

        var tags = await context.Tags
            .ToDictionaryAsync(t => t.Name);

        var lessonTags = new List<LessonTag>();

        void AddTag(Lesson lesson, string tagName)
        {
            if (!tags.TryGetValue(tagName, out var tag))
                return;



            lessonTags.Add(new LessonTag
            {
                LessonId = lesson.Id,
                TagId = tag.Id
            });
        }

        foreach (var lesson in lessons)
        {
            switch (lesson.DisplayOrder)
            {
                case 1:
                    AddTag(lesson, "Introduction");
                    AddTag(lesson, "Concept");
                    AddTag(lesson, "Definition");
                    AddTag(lesson, "Example");
                    break;

                case 2:
                    AddTag(lesson, "Theory");
                    AddTag(lesson, "Worked Example");
                    AddTag(lesson, "Step-by-Step");

                    // adds - Formula only when appropriate
                    if (lesson.Title.Contains("Formula", StringComparison.OrdinalIgnoreCase))
                        AddTag(lesson, "Formula");

                    if (lesson.Title.Contains("Proof", StringComparison.OrdinalIgnoreCase))
                        AddTag(lesson, "Proof");

                    break;

                case 3:
                    AddTag(lesson, "Practice");
                    AddTag(lesson, "Exercise");
                    AddTag(lesson, "Quiz");
                    AddTag(lesson, "Revision");

                    if (lesson.Title.Contains("Application", StringComparison.OrdinalIgnoreCase))
                        AddTag(lesson, "Real World");

                    break;
            }
        }






        context.LessonTags.AddRange(lessonTags);
        await context.SaveChangesAsync();
    }
}