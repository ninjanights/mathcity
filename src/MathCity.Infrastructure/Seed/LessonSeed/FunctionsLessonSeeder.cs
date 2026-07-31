using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class FunctionsLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {

        if (await context.Lessons.AnyAsync())
            return;
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {

           
// Relations


new Lesson
{
    TopicId = topics["Relations"].Id,
    Title = "Introduction to Relations",
    Slug = "introduction-to-relations",
    Summary = "Learn the fundamentals of relations, understand how elements of two sets are connected, and explore ordered pairs and their representations.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Relations"].Id,
    Title = "Types and Properties of Relations",
    Slug = "types-and-properties-of-relations",
    Summary = "Explore different types of relations, including reflexive, symmetric, transitive, and equivalence relations, along with methods of representation.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Relations"].Id,
    Title = "Applications and Practice of Relations",
    Slug = "applications-and-practice-of-relations",
    Summary = "Apply relation concepts to solve mathematical problems and explore their applications in databases, computer science, logic, and real-world modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Types of Functions


new Lesson
{
    TopicId = topics["Types of Functions"].Id,
    Title = "Introduction to Types of Functions",
    Slug = "introduction-to-types-of-functions",
    Summary = "Learn the fundamentals of functions and explore different types such as one-one, many-one, onto, into, constant, identity, and inverse functions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Types of Functions"].Id,
    Title = "Understanding and Classifying Types of Functions",
    Slug = "understanding-and-classifying-types-of-functions",
    Summary = "Explore the characteristics, domains, codomains, and ranges of various function types, and learn how to identify and classify them through examples.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Types of Functions"].Id,
    Title = "Applications and Practice of Types of Functions",
    Slug = "applications-and-practice-of-types-of-functions",
    Summary = "Apply different types of functions to solve mathematical problems and explore their applications in computer science, economics, engineering, and data modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Domain & Range


new Lesson
{
    TopicId = topics["Domain & Range"].Id,
    Title = "Introduction to Domain & Range",
    Slug = "introduction-to-domain-and-range",
    Summary = "Learn the fundamentals of domain and range, understand their meaning, and identify the set of allowable inputs and corresponding outputs of a function.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Domain & Range"].Id,
    Title = "Finding Domain & Range of Functions",
    Slug = "finding-domain-and-range-of-functions",
    Summary = "Explore methods for determining the domain and range of algebraic, rational, radical, exponential, logarithmic, and trigonometric functions using equations and graphs.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Domain & Range"].Id,
    Title = "Applications and Practice of Domain & Range",
    Slug = "applications-and-practice-of-domain-and-range",
    Summary = "Apply domain and range concepts to solve mathematical problems and explore their applications in programming, engineering, physics, economics, and data analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Composite Functions


new Lesson
{
    TopicId = topics["Composite Functions"].Id,
    Title = "Introduction to Composite Functions",
    Slug = "introduction-to-composite-functions",
    Summary = "Learn the fundamentals of composite functions and understand how one function can be applied to the output of another function.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Composite Functions"].Id,
    Title = "Evaluating and Solving Composite Functions",
    Slug = "evaluating-and-solving-composite-functions",
    Summary = "Explore how to evaluate composite functions, determine their domains, simplify compositions, and solve problems involving function composition.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Composite Functions"].Id,
    Title = "Applications and Practice of Composite Functions",
    Slug = "applications-and-practice-of-composite-functions",
    Summary = "Apply composite functions to solve advanced mathematical problems and explore their applications in computer science, engineering, economics, and mathematical modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Inverse Functions


new Lesson
{
    TopicId = topics["Inverse Functions"].Id,
    Title = "Introduction to Inverse Functions",
    Slug = "introduction-to-inverse-functions",
    Summary = "Learn the fundamentals of inverse functions, understand how they reverse the effect of a function, and explore the conditions required for an inverse to exist.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Inverse Functions"].Id,
    Title = "Finding and Verifying Inverse Functions",
    Slug = "finding-and-verifying-inverse-functions",
    Summary = "Explore methods for finding inverse functions, verify inverses using composition, and solve problems involving one-to-one functions and inverse relationships.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Inverse Functions"].Id,
    Title = "Applications and Practice of Inverse Functions",
    Slug = "applications-and-practice-of-inverse-functions",
    Summary = "Apply inverse function concepts to solve advanced mathematical problems and explore their applications in science, engineering, computer graphics, cryptography, and data analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Graphing Functions


new Lesson
{
    TopicId = topics["Graphing Functions"].Id,
    Title = "Introduction to Graphing Functions",
    Slug = "introduction-to-graphing-functions",
    Summary = "Learn the fundamentals of graphing functions, understand coordinate plotting, and explore how equations are represented visually on the Cartesian plane.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Graphing Functions"].Id,
    Title = "Analyzing and Sketching Function Graphs",
    Slug = "analyzing-and-sketching-function-graphs",
    Summary = "Explore techniques for sketching and interpreting graphs of linear, quadratic, polynomial, exponential, logarithmic, and other common functions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Graphing Functions"].Id,
    Title = "Applications and Practice of Graphing Functions",
    Slug = "applications-and-practice-of-graphing-functions",
    Summary = "Apply graphing techniques to solve mathematical problems and explore real-world applications in science, engineering, economics, data analysis, and computer graphics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Piecewise Functions


new Lesson
{
    TopicId = topics["Piecewise Functions"].Id,
    Title = "Introduction to Piecewise Functions",
    Slug = "introduction-to-piecewise-functions",
    Summary = "Learn the fundamentals of piecewise functions and understand how different rules are used to define a function over different intervals of its domain.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Piecewise Functions"].Id,
    Title = "Evaluating and Graphing Piecewise Functions",
    Slug = "evaluating-and-graphing-piecewise-functions",
    Summary = "Explore how to evaluate piecewise functions, graph them accurately, and analyse their continuity, domains, and ranges.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Piecewise Functions"].Id,
    Title = "Applications and Practice of Piecewise Functions",
    Slug = "applications-and-practice-of-piecewise-functions",
    Summary = "Apply piecewise functions to solve advanced mathematical problems and model real-world situations such as tax brackets, shipping costs, utility pricing, and signal processing.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Transformations of Functions


new Lesson
{
    TopicId = topics["Transformations of Functions"].Id,
    Title = "Introduction to Transformations of Functions",
    Slug = "introduction-to-transformations-of-functions",
    Summary = "Learn the fundamentals of function transformations and understand how translations, reflections, stretches, and compressions change the graph of a function.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Transformations of Functions"].Id,
    Title = "Graphing and Analyzing Function Transformations",
    Slug = "graphing-and-analyzing-function-transformations",
    Summary = "Explore horizontal and vertical shifts, reflections, stretches, and compressions, and learn how transformation rules affect the graphs of common functions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Transformations of Functions"].Id,
    Title = "Applications and Practice of Function Transformations",
    Slug = "applications-and-practice-of-function-transformations",
    Summary = "Apply function transformation concepts to solve advanced mathematical problems and explore their applications in computer graphics, engineering, physics, animation, and data modelling.",
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