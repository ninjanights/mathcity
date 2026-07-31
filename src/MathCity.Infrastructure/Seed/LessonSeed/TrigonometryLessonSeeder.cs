using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class TrigonometryLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {

        if (await context.Lessons.AnyAsync())
            return;
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            // ==========================================================
// Trigonometric Ratios
// ==========================================================

new Lesson
{
    TopicId = topics["Trigonometric Ratios"].Id,
    Title = "Introduction to Trigonometric Ratios",
    Slug = "introduction-to-trigonometric-ratios",
    Summary = "Learn the fundamental concepts of trigonometric ratios, including sine, cosine, tangent, and their relationship with angles in right-angled triangles.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Trigonometric Ratios"].Id,
    Title = "Understanding and Solving Trigonometric Ratios",
    Slug = "understanding-and-solving-trigonometric-ratios",
    Summary = "Explore how to calculate sine, cosine, and tangent ratios and solve problems involving unknown sides and angles in right-angled triangles.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Trigonometric Ratios"].Id,
    Title = "Applications and Practice of Trigonometric Ratios",
    Slug = "applications-and-practice-of-trigonometric-ratios",
    Summary = "Apply trigonometric ratios to solve advanced problems in measurement, engineering, physics, navigation, and real-world situations.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// ==========================================================
// Trigonometric Identities
// ==========================================================

new Lesson
{
    TopicId = topics["Trigonometric Identities"].Id,
    Title = "Introduction to Trigonometric Identities",
    Slug = "introduction-to-trigonometric-identities",
    Summary = "Learn the fundamental trigonometric identities, including reciprocal, quotient, and Pythagorean identities, and understand their importance in simplifying expressions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Trigonometric Identities"].Id,
    Title = "Simplifying Expressions Using Trigonometric Identities",
    Slug = "simplifying-expressions-using-trigonometric-identities",
    Summary = "Explore how to apply trigonometric identities to simplify expressions, prove relationships, and solve mathematical problems step-by-step.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Trigonometric Identities"].Id,
    Title = "Applications and Practice of Trigonometric Identities",
    Slug = "applications-and-practice-of-trigonometric-identities",
    Summary = "Apply trigonometric identities to solve advanced problems in mathematics, physics, engineering, and real-world calculations involving angles and waves.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// ==========================================================
// Compound Angles
// ==========================================================

new Lesson
{
    TopicId = topics["Compound Angles"].Id,
    Title = "Introduction to Compound Angles",
    Slug = "introduction-to-compound-angles",
    Summary = "Learn the concept of compound angles and understand angle addition and subtraction formulas in trigonometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Compound Angles"].Id,
    Title = "Solving Problems Using Compound Angle Formulas",
    Slug = "solving-problems-using-compound-angle-formulas",
    Summary = "Explore sine, cosine, and tangent compound angle formulas and apply them to simplify expressions and solve trigonometric problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Compound Angles"].Id,
    Title = "Applications and Practice of Compound Angles",
    Slug = "applications-and-practice-of-compound-angles",
    Summary = "Apply compound angle concepts to advanced trigonometric problems, mathematical proofs, physics, and engineering applications.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// ==========================================================
// Double & Half Angles
// ==========================================================

new Lesson
{
    TopicId = topics["Double & Half Angles"].Id,
    Title = "Introduction to Double & Half Angles",
    Slug = "introduction-to-double-and-half-angles",
    Summary = "Learn the concepts of double and half angles and understand how they are derived from basic trigonometric identities.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Double & Half Angles"].Id,
    Title = "Solving Problems Using Double & Half Angle Formulas",
    Slug = "solving-problems-using-double-and-half-angle-formulas",
    Summary = "Explore double angle and half angle formulas for sine, cosine, and tangent and apply them to simplify expressions and solve trigonometric problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Double & Half Angles"].Id,
    Title = "Applications and Practice of Double & Half Angles",
    Slug = "applications-and-practice-of-double-and-half-angles",
    Summary = "Apply double and half angle concepts to advanced trigonometric problems, mathematical proofs, physics, engineering, and angle analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// ==========================================================
// Inverse Trigonometric Functions
// ==========================================================

new Lesson
{
    TopicId = topics["Inverse Trigonometric Functions"].Id,
    Title = "Introduction to Inverse Trigonometric Functions",
    Slug = "introduction-to-inverse-trigonometric-functions",
    Summary = "Learn the fundamentals of inverse trigonometric functions, their notation, principal values, domains, and ranges, and understand how they relate angles to trigonometric ratios.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Inverse Trigonometric Functions"].Id,
    Title = "Solving Problems Using Inverse Trigonometric Functions",
    Slug = "solving-problems-using-inverse-trigonometric-functions",
    Summary = "Explore how to evaluate inverse trigonometric functions, solve equations involving inverse ratios, and determine unknown angles in mathematical problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Inverse Trigonometric Functions"].Id,
    Title = "Applications and Practice of Inverse Trigonometric Functions",
    Slug = "applications-and-practice-of-inverse-trigonometric-functions",
    Summary = "Apply inverse trigonometric functions to solve advanced problems in geometry, physics, engineering, navigation, and real-world angle calculations.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// ==========================================================
// Trigonometric Equations
// ==========================================================

new Lesson
{
    TopicId = topics["Trigonometric Equations"].Id,
    Title = "Introduction to Trigonometric Equations",
    Slug = "introduction-to-trigonometric-equations",
    Summary = "Learn the fundamentals of trigonometric equations, understand their forms, and explore methods for finding unknown angles that satisfy trigonometric relationships.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Trigonometric Equations"].Id,
    Title = "Solving Trigonometric Equations",
    Slug = "solving-trigonometric-equations",
    Summary = "Explore techniques for solving basic and advanced trigonometric equations using identities, algebraic manipulation, and graphical reasoning.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Trigonometric Equations"].Id,
    Title = "Applications and Practice of Trigonometric Equations",
    Slug = "applications-and-practice-of-trigonometric-equations",
    Summary = "Apply trigonometric equations to solve problems in geometry, physics, engineering, wave analysis, and other real-world mathematical applications.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// ==========================================================
// Heights & Distances
// ==========================================================

new Lesson
{
    TopicId = topics["Heights & Distances"].Id,
    Title = "Introduction to Heights & Distances",
    Slug = "introduction-to-heights-and-distances",
    Summary = "Learn the fundamentals of heights and distances, and understand how trigonometric ratios are used to measure inaccessible heights and distances.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Heights & Distances"].Id,
    Title = "Solving Problems Using Heights & Distances",
    Slug = "solving-problems-using-heights-and-distances",
    Summary = "Explore techniques for solving heights and distances problems using angles of elevation, angles of depression, and trigonometric ratios.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Heights & Distances"].Id,
    Title = "Applications and Practice of Heights & Distances",
    Slug = "applications-and-practice-of-heights-and-distances",
    Summary = "Apply heights and distances concepts to solve real-world problems in surveying, navigation, architecture, engineering, and construction.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// ==========================================================
// Graphs of Trigonometric Functions
// ==========================================================

new Lesson
{
    TopicId = topics["Graphs of Trigonometric Functions"].Id,
    Title = "Introduction to Graphs of Trigonometric Functions",
    Slug = "introduction-to-graphs-of-trigonometric-functions",
    Summary = "Learn the fundamentals of trigonometric graphs, including the shapes, periods, amplitudes, and key characteristics of sine, cosine, and tangent functions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Graphs of Trigonometric Functions"].Id,
    Title = "Understanding and Analyzing Trigonometric Graphs",
    Slug = "understanding-and-analyzing-trigonometric-graphs",
    Summary = "Explore the graphs of sine, cosine, tangent, cotangent, secant, and cosecant functions, and understand transformations such as shifts, reflections, and scaling.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Graphs of Trigonometric Functions"].Id,
    Title = "Applications and Practice of Trigonometric Graphs",
    Slug = "applications-and-practice-of-trigonometric-graphs",
    Summary = "Apply trigonometric graphs to solve advanced problems involving periodic motion, sound waves, light waves, engineering, physics, and real-world modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

        };

        await context.Lessons.AddRangeAsync(lessons);
        await context.SaveChangesAsync();
    }
}