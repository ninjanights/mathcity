
// Differential Equations Lesson Seeder


using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class DifferentialEquationsLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {

        if (await context.Lessons.AnyAsync())
            return;
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            
// Introduction


new Lesson
{
    TopicId = topics["Introduction"].Id,
    Title = "Introduction to Differential Equations",
    Slug = "introduction-to-differential-equations",
    Summary = "Learn the fundamentals of differential equations, understand how equations describe relationships between changing quantities, and explore their importance in mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Introduction"].Id,
    Title = "Types and Classification of Differential Equations",
    Slug = "types-and-classification-of-differential-equations",
    Summary = "Explore ordinary and partial differential equations, order and degree of equations, and different methods used to classify differential equations.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Introduction"].Id,
    Title = "Applications and Practice of Differential Equations",
    Slug = "applications-and-practice-of-differential-equations",
    Summary = "Apply differential equation concepts to model real-world systems and explore applications in physics, engineering, biology, economics, robotics, and artificial intelligence.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// First Order Differential Equations


new Lesson
{
    TopicId = topics["First Order Differential Equations"].Id,
    Title = "Introduction to First Order Differential Equations",
    Slug = "introduction-to-first-order-differential-equations",
    Summary = "Learn the fundamentals of first order differential equations, understand equations involving first derivatives, and explore their role in modeling changing systems.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["First Order Differential Equations"].Id,
    Title = "Methods for Solving First Order Differential Equations",
    Slug = "methods-for-solving-first-order-differential-equations",
    Summary = "Explore techniques for solving first order differential equations including separation of variables, linear equations, exact equations, and integrating factors.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["First Order Differential Equations"].Id,
    Title = "Applications and Practice of First Order Differential Equations",
    Slug = "applications-and-practice-of-first-order-differential-equations",
    Summary = "Apply first order differential equation methods to solve real-world problems involving population growth, radioactive decay, heat transfer, circuits, economics, and physical systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Separable Equations


new Lesson
{
    TopicId = topics["Separable Equations"].Id,
    Title = "Introduction to Separable Equations",
    Slug = "introduction-to-separable-equations",
    Summary = "Learn the fundamentals of separable differential equations, understand how variables can be separated, and explore the basic approach used to solve these equations.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Separable Equations"].Id,
    Title = "Solving Separable Differential Equations",
    Slug = "solving-separable-differential-equations",
    Summary = "Explore the step-by-step process of separating variables, integrating both sides, applying initial conditions, and finding solutions to separable equations.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Separable Equations"].Id,
    Title = "Applications and Practice of Separable Equations",
    Slug = "applications-and-practice-of-separable-equations",
    Summary = "Apply separable equation techniques to model real-world systems including population growth, radioactive decay, cooling processes, chemical reactions, and physical phenomena.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Linear Differential Equations


new Lesson
{
    TopicId = topics["Linear Differential Equations"].Id,
    Title = "Introduction to Linear Differential Equations",
    Slug = "introduction-to-linear-differential-equations",
    Summary = "Learn the fundamentals of linear differential equations, understand their structure, and explore how they describe relationships involving a function and its derivatives.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Linear Differential Equations"].Id,
    Title = "Solving Linear Differential Equations",
    Slug = "solving-linear-differential-equations",
    Summary = "Explore methods for solving first-order linear differential equations using integrating factors, general solutions, and initial value problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Linear Differential Equations"].Id,
    Title = "Applications and Practice of Linear Differential Equations",
    Slug = "applications-and-practice-of-linear-differential-equations",
    Summary = "Apply linear differential equation techniques to solve real-world problems involving circuits, population models, economics, physics, engineering, and dynamic systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Homogeneous Equations


new Lesson
{
    TopicId = topics["Homogeneous Equations"].Id,
    Title = "Introduction to Homogeneous Differential Equations",
    Slug = "introduction-to-homogeneous-differential-equations",
    Summary = "Learn the fundamentals of homogeneous differential equations, understand their structure, and explore how substitutions help transform them into solvable forms.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Homogeneous Equations"].Id,
    Title = "Methods for Solving Homogeneous Equations",
    Slug = "methods-for-solving-homogeneous-equations",
    Summary = "Explore techniques for solving homogeneous differential equations using variable substitution, separation of variables, and integration methods.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Homogeneous Equations"].Id,
    Title = "Applications and Practice of Homogeneous Equations",
    Slug = "applications-and-practice-of-homogeneous-equations",
    Summary = "Apply homogeneous differential equation concepts to solve advanced problems and explore applications in physics, engineering, fluid dynamics, economics, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Exact Equations


new Lesson
{
    TopicId = topics["Exact Equations"].Id,
    Title = "Introduction to Exact Equations",
    Slug = "introduction-to-exact-equations",
    Summary = "Learn the fundamentals of exact differential equations, understand the conditions for exactness, and explore how these equations represent relationships between variables.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Exact Equations"].Id,
    Title = "Solving Exact Differential Equations",
    Slug = "solving-exact-differential-equations",
    Summary = "Explore methods for testing exactness, finding potential functions, and solving exact differential equations using integration techniques.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Exact Equations"].Id,
    Title = "Applications and Practice of Exact Equations",
    Slug = "applications-and-practice-of-exact-equations",
    Summary = "Apply exact differential equation techniques to solve advanced problems and explore applications in physics, engineering, thermodynamics, fluid mechanics, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Higher Order Differential Equations


new Lesson
{
    TopicId = topics["Higher Order Differential Equations"].Id,
    Title = "Introduction to Higher Order Differential Equations",
    Slug = "introduction-to-higher-order-differential-equations",
    Summary = "Learn the fundamentals of higher order differential equations, understand equations involving second and higher derivatives, and explore their importance in advanced mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Higher Order Differential Equations"].Id,
    Title = "Methods for Solving Higher Order Differential Equations",
    Slug = "methods-for-solving-higher-order-differential-equations",
    Summary = "Explore techniques for solving higher order differential equations including characteristic equations, complementary solutions, particular solutions, and linear differential equation methods.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Higher Order Differential Equations"].Id,
    Title = "Applications and Practice of Higher Order Differential Equations",
    Slug = "applications-and-practice-of-higher-order-differential-equations",
    Summary = "Apply higher order differential equation concepts to solve advanced problems and explore applications in physics, engineering, vibrations, control systems, mechanics, robotics, and scientific modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Applications


new Lesson
{
    TopicId = topics["Applications"].Id,
    Title = "Introduction to Applications of Differential Equations",
    Slug = "introduction-to-applications-of-differential-equations",
    Summary = "Learn how differential equations are used to represent real-world systems and understand how changing quantities can be modeled mathematically.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Applications"].Id,
    Title = "Mathematical Modeling with Differential Equations",
    Slug = "mathematical-modeling-with-differential-equations",
    Summary = "Explore how differential equations model population growth, motion, heat transfer, electrical circuits, chemical reactions, and other dynamic systems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Applications"].Id,
    Title = "Advanced Applications and Practice of Differential Equations",
    Slug = "advanced-applications-and-practice-of-differential-equations",
    Summary = "Apply differential equation techniques to solve complex real-world problems in engineering, physics, biology, economics, robotics, artificial intelligence, and scientific research.",
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