using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed;

public static class ChapterSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var math = await context.Subjects
            .SingleAsync(x => x.Slug == "mathematics");



        var chapters = new List<Chapter>
{
    new()
    {
        SubjectId = math.Id,
        Title = "Algebra",
        Description = "Algebra teaches you how to solve puzzles using numbers and letters. You'll learn to find unknown values, build equations, and recognize patterns. It forms the foundation of programming, engineering, finance, and almost every branch of mathematics.",
        DisplayOrder = 1
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Geometry",
        Description = "Geometry helps you understand shapes, sizes, angles, and space. You'll discover how the world is built through circles, triangles, and polygons. Architects, artists, designers, and engineers use geometry every day to create amazing things.",
        DisplayOrder = 2
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Coordinate Geometry",
        Description = "Coordinate Geometry connects algebra with graphs by placing points on a coordinate plane. You'll learn how lines, circles, and curves describe movement and position. It is widely used in computer graphics, maps, games, robotics, and GPS navigation.",
        DisplayOrder = 3
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Trigonometry",
        Description = "Trigonometry explores the relationship between angles and sides of triangles. You'll understand how to measure heights, distances, and waves. It powers fields like astronomy, architecture, navigation, engineering, and computer graphics.",
        DisplayOrder = 4
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Functions",
        Description = "Functions show how one value changes into another through simple mathematical rules. You'll learn to describe relationships, predict outcomes, and build models. Functions are used everywhere from programming and AI to economics and physics.",
        DisplayOrder = 5
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Sequences & Series",
        Description = "Sequences and Series reveal beautiful patterns hidden inside numbers. You'll discover how numbers grow, repeat, and combine to form larger ideas. They are used in finance, computer science, music, and scientific calculations.",
        DisplayOrder = 6
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Matrices & Determinants",
        Description = "Matrices organize numbers into rows and columns to solve many problems at once. You'll learn powerful techniques used in computer graphics, machine learning, robotics, cryptography, and scientific computing.",
        DisplayOrder = 7
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Vectors",
        Description = "Vectors describe both direction and magnitude, showing not only how far something moves but also where it goes. They are essential in physics, animation, games, robotics, aviation, and artificial intelligence.",
        DisplayOrder = 8
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Probability",
        Description = "Probability helps you understand uncertainty by measuring how likely something is to happen. You'll learn to make better predictions and decisions. It is used in weather forecasting, medicine, finance, AI, and everyday life.",
        DisplayOrder = 9
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Statistics",
        Description = "Statistics teaches you how to collect, organize, and understand data. You'll learn how numbers tell stories and help people make smarter decisions. Statistics powers business, healthcare, sports, research, and data science.",
        DisplayOrder = 10
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Calculus",
        Description = "Calculus explains how things change and move over time. You'll learn to study motion, growth, curves, and change itself. Scientists, engineers, economists, and AI researchers use calculus to solve complex real-world problems.",
        DisplayOrder = 11
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Differential Equations",
        Description = "Differential Equations describe how changing quantities influence one another. You'll model everything from population growth to planetary motion. They are widely used in engineering, biology, economics, and physics.",
        DisplayOrder = 12
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Complex Numbers",
        Description = "Complex Numbers extend mathematics beyond ordinary numbers by introducing imaginary values. They help solve problems that real numbers cannot. They are fundamental in electronics, signal processing, quantum physics, and engineering.",
        DisplayOrder = 13
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Discrete Mathematics",
        Description = "Discrete Mathematics studies separate objects like graphs, networks, logic, and counting instead of continuous values. It forms the backbone of computer science, algorithms, cybersecurity, and software engineering.",
        DisplayOrder = 14
    },

    new()
    {
        SubjectId = math.Id,
        Title = "Logic & Set Theory",
        Description = "Mathematical Logic and Set Theory teach you how mathematical thinking is built from simple rules and collections. You'll learn how reasoning works and how mathematics is organized. These ideas are the foundation of programming languages, databases, AI, and modern mathematics.",
        DisplayOrder = 15
    }
};
        

        foreach (var chapter in chapters)
        {
            var existing = await context.Chapters
                .FirstOrDefaultAsync(x =>
                    x.SubjectId == math.Id &&
                    x.Title == chapter.Title);

            if (existing == null)
            {
                context.Chapters.Add(chapter);
                continue;
            }

            existing.Description = chapter.Description;
            existing.DisplayOrder = chapter.DisplayOrder;
        }

        await context.SaveChangesAsync();
    }
}