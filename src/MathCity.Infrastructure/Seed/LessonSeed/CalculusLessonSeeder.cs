using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class CalculusLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            
// Limits


new Lesson
{
    TopicId = topics["Limits"].Id,
    Title = "Introduction to Limits",
    Slug = "introduction-to-limits",
    Summary = "Learn the fundamentals of limits, understand the concept of approaching values, and explore how limits form the foundation of calculus.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Limits"].Id,
    Title = "Calculating and Evaluating Limits",
    Slug = "calculating-and-evaluating-limits",
    Summary = "Explore limit laws, techniques for evaluating limits, one-sided limits, infinite limits, and methods for solving limit problems using algebraic and graphical approaches.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Limits"].Id,
    Title = "Applications and Practice of Limits",
    Slug = "applications-and-practice-of-limits",
    Summary = "Apply limit concepts to solve advanced calculus problems and explore applications in continuity, derivatives, physics, engineering, economics, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Continuity


new Lesson
{
    TopicId = topics["Continuity"].Id,
    Title = "Introduction to Continuity",
    Slug = "introduction-to-continuity",
    Summary = "Learn the fundamentals of continuity, understand when a function behaves smoothly, and explore the connection between limits and continuous functions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Continuity"].Id,
    Title = "Properties and Types of Continuity",
    Slug = "properties-and-types-of-continuity",
    Summary = "Explore conditions for continuity, types of discontinuities, continuous functions, and methods to determine whether a function is continuous at a given point.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Continuity"].Id,
    Title = "Applications and Practice of Continuity",
    Slug = "applications-and-practice-of-continuity",
    Summary = "Apply continuity concepts to solve advanced calculus problems and explore applications in physics, engineering, economics, mathematical modeling, and real-world systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Differentiation


new Lesson
{
    TopicId = topics["Differentiation"].Id,
    Title = "Introduction to Differentiation",
    Slug = "introduction-to-differentiation",
    Summary = "Learn the fundamentals of differentiation, understand derivatives as rates of change, and explore how calculus describes the behavior of functions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Differentiation"].Id,
    Title = "Rules and Techniques of Differentiation",
    Slug = "rules-and-techniques-of-differentiation",
    Summary = "Explore differentiation rules including power rule, product rule, quotient rule, and chain rule, and learn techniques for finding derivatives of different functions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Differentiation"].Id,
    Title = "Applications and Practice of Differentiation",
    Slug = "applications-and-practice-of-differentiation",
    Summary = "Apply differentiation concepts to solve advanced calculus problems and explore applications in physics, engineering, economics, optimization, artificial intelligence, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Applications of Derivatives


new Lesson
{
    TopicId = topics["Applications of Derivatives"].Id,
    Title = "Introduction to Applications of Derivatives",
    Slug = "introduction-to-applications-of-derivatives",
    Summary = "Learn how derivatives are used to analyze real-world changes, including rates of change, motion, growth, and optimization problems.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Applications of Derivatives"].Id,
    Title = "Optimization and Related Rates",
    Slug = "optimization-and-related-rates",
    Summary = "Explore applications of derivatives including maximum and minimum values, related rates, increasing and decreasing functions, and curve analysis techniques.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Applications of Derivatives"].Id,
    Title = "Applications and Practice of Derivatives",
    Slug = "applications-and-practice-of-derivatives",
    Summary = "Apply derivative concepts to solve advanced calculus problems and explore applications in physics, engineering, economics, artificial intelligence, machine learning, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Indefinite Integration


new Lesson
{
    TopicId = topics["Indefinite Integration"].Id,
    Title = "Introduction to Indefinite Integration",
    Slug = "introduction-to-indefinite-integration",
    Summary = "Learn the fundamentals of indefinite integration, understand antiderivatives, and explore how integration reverses the process of differentiation.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Indefinite Integration"].Id,
    Title = "Methods and Techniques of Indefinite Integration",
    Slug = "methods-and-techniques-of-indefinite-integration",
    Summary = "Explore integration rules, substitution methods, integration by parts, and techniques for finding antiderivatives of different functions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Indefinite Integration"].Id,
    Title = "Applications and Practice of Indefinite Integration",
    Slug = "applications-and-practice-of-indefinite-integration",
    Summary = "Apply indefinite integration concepts to solve advanced calculus problems and explore applications in physics, engineering, economics, computer science, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Definite Integration


new Lesson
{
    TopicId = topics["Definite Integration"].Id,
    Title = "Introduction to Definite Integration",
    Slug = "introduction-to-definite-integration",
    Summary = "Learn the fundamentals of definite integration, understand the concept of accumulated area, and explore how integrals measure quantities over a specific interval.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Definite Integration"].Id,
    Title = "Fundamental Theorem and Evaluation of Definite Integrals",
    Slug = "fundamental-theorem-and-evaluation-of-definite-integrals",
    Summary = "Explore definite integral properties, the Fundamental Theorem of Calculus, evaluation techniques, and methods for finding areas under curves.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Definite Integration"].Id,
    Title = "Applications and Practice of Definite Integration",
    Slug = "applications-and-practice-of-definite-integration",
    Summary = "Apply definite integration concepts to solve advanced calculus problems and explore applications in physics, engineering, probability, economics, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Applications of Integration


new Lesson
{
    TopicId = topics["Applications of Integration"].Id,
    Title = "Introduction to Applications of Integration",
    Slug = "introduction-to-applications-of-integration",
    Summary = "Learn how integration is used to calculate accumulated quantities, areas, and changes over intervals in real-world situations.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Applications of Integration"].Id,
    Title = "Area, Volume, and Real-World Applications of Integration",
    Slug = "area-volume-and-real-world-applications-of-integration",
    Summary = "Explore applications of integration including finding areas under curves, volumes of solids, distance traveled, and other mathematical modeling problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Applications of Integration"].Id,
    Title = "Advanced Applications and Practice of Integration",
    Slug = "advanced-applications-and-practice-of-integration",
    Summary = "Apply integration techniques to solve advanced calculus problems and explore applications in physics, engineering, economics, probability, computer science, and scientific modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Parametric Equations


new Lesson
{
    TopicId = topics["Parametric Equations"].Id,
    Title = "Introduction to Parametric Equations",
    Slug = "introduction-to-parametric-equations",
    Summary = "Learn the fundamentals of parametric equations, understand how curves can be represented using parameters, and explore their role in describing motion and geometric paths.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Parametric Equations"].Id,
    Title = "Graphing and Differentiating Parametric Equations",
    Slug = "graphing-and-differentiating-parametric-equations",
    Summary = "Explore how to graph parametric curves, convert between Cartesian and parametric forms, and apply differentiation techniques to find slopes and rates of change.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Parametric Equations"].Id,
    Title = "Applications and Practice of Parametric Equations",
    Slug = "applications-and-practice-of-parametric-equations",
    Summary = "Apply parametric equation concepts to solve advanced calculus problems and explore applications in physics, engineering, robotics, animation, computer graphics, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Polar Coordinates


new Lesson
{
    TopicId = topics["Polar Coordinates"].Id,
    Title = "Introduction to Polar Coordinates",
    Slug = "introduction-to-polar-coordinates",
    Summary = "Learn the fundamentals of polar coordinates, understand the relationship between radius and angle, and explore how points are represented in a polar system.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Polar Coordinates"].Id,
    Title = "Graphs and Transformations in Polar Coordinates",
    Slug = "graphs-and-transformations-in-polar-coordinates",
    Summary = "Explore polar equations, conversion between Cartesian and polar coordinates, and methods for graphing curves such as circles, spirals, and other polar shapes.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Polar Coordinates"].Id,
    Title = "Applications and Practice of Polar Coordinates",
    Slug = "applications-and-practice-of-polar-coordinates",
    Summary = "Apply polar coordinate concepts to solve advanced calculus problems and explore applications in physics, engineering, astronomy, robotics, navigation, and mathematical modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Multivariable Calculus


new Lesson
{
    TopicId = topics["Multivariable Calculus"].Id,
    Title = "Introduction to Multivariable Calculus",
    Slug = "introduction-to-multivariable-calculus",
    Summary = "Learn the fundamentals of multivariable calculus, understand functions of several variables, and explore how calculus extends beyond single-variable functions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Multivariable Calculus"].Id,
    Title = "Partial Derivatives and Multiple Integrals",
    Slug = "partial-derivatives-and-multiple-integrals",
    Summary = "Explore partial derivatives, gradients, directional derivatives, double and triple integrals, and techniques for analyzing functions with multiple variables.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Multivariable Calculus"].Id,
    Title = "Applications and Practice of Multivariable Calculus",
    Slug = "applications-and-practice-of-multivariable-calculus",
    Summary = "Apply multivariable calculus concepts to solve advanced problems and explore applications in physics, engineering, computer graphics, robotics, machine learning, and scientific modeling.",
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