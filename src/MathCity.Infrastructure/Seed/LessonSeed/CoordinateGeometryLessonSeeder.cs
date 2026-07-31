using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed;

public static class CoordinateGeometryLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {


        if (await context.Lessons.AnyAsync(l => l.Topic.Chapter.Title == "Coordinate Geometry"))
            return;

        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            new Lesson
{
    TopicId = topics["Cartesian Plane"].Id,
    Title = "Introduction to Cartesian Plane",
    Slug = "introduction-to-cartesian-plane",
    Summary = "Learn the fundamentals of the Cartesian plane, coordinate axes, quadrants, and how points are represented using ordered pairs.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Cartesian Plane"].Id,
    Title = "Understanding Coordinates and Quadrants",
    Slug = "understanding-coordinates-and-quadrants",
    Summary = "Explore coordinate systems, plotting points, and identifying locations using different quadrants of the Cartesian plane.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Cartesian Plane"].Id,
    Title = "Applications and Practice of Cartesian Plane",
    Slug = "applications-and-practice-of-cartesian-plane",
    Summary = "Apply Cartesian plane concepts to solve graphing problems and understand real-world coordinate applications.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Distance Formula

new Lesson
{
    TopicId = topics["Distance Formula"].Id,
    Title = "Introduction to Distance Formula",
    Slug = "introduction-to-distance-formula",
    Summary = "Learn the distance formula, its derivation from the Pythagorean theorem, and how it is used to find the distance between two points on a coordinate plane.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Distance Formula"].Id,
    Title = "Solving Problems Using Distance Formula",
    Slug = "solving-problems-using-distance-formula",
    Summary = "Practice calculating distances between coordinate points using the distance formula and solve coordinate geometry problems step-by-step.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Distance Formula"].Id,
    Title = "Applications and Practice of Distance Formula",
    Slug = "applications-and-practice-of-distance-formula",
    Summary = "Apply the distance formula in geometry, measurement, and real-world coordinate problems through examples and exercises.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Midpoint Formula

new Lesson
{
    TopicId = topics["Midpoint Formula"].Id,
    Title = "Introduction to Midpoint Formula",
    Slug = "introduction-to-midpoint-formula",
    Summary = "Learn the midpoint formula and understand how to find the exact center point between two coordinates on a line segment.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Midpoint Formula"].Id,
    Title = "Solving Problems Using Midpoint Formula",
    Slug = "solving-problems-using-midpoint-formula",
    Summary = "Practice finding midpoints between coordinate points and apply the formula to solve coordinate geometry problems step-by-step.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Midpoint Formula"].Id,
    Title = "Applications and Practice of Midpoint Formula",
    Slug = "applications-and-practice-of-midpoint-formula",
    Summary = "Apply midpoint concepts in geometry, coordinate analysis, and real-world problems through guided examples and exercises.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Section Formula

new Lesson
{
    TopicId = topics["Section Formula"].Id,
    Title = "Introduction to Section Formula",
    Slug = "introduction-to-section-formula",
    Summary = "Learn the section formula and understand how a line segment is divided internally and externally in a given ratio on the coordinate plane.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Section Formula"].Id,
    Title = "Solving Problems Using Section Formula",
    Slug = "solving-problems-using-section-formula",
    Summary = "Practice finding coordinates of points dividing a line segment in different ratios using the section formula.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Section Formula"].Id,
    Title = "Applications and Practice of Section Formula",
    Slug = "applications-and-practice-of-section-formula",
    Summary = "Apply section formula concepts to coordinate geometry problems, geometric constructions, and real-world measurement scenarios.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Straight Line

new Lesson
{
    TopicId = topics["Straight Line"].Id,
    Title = "Introduction to Straight Line",
    Slug = "introduction-to-straight-line",
    Summary = "Learn the fundamentals of straight lines, their equations, slope, intercepts, and representation on the coordinate plane.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Straight Line"].Id,
    Title = "Equations and Properties of Straight Lines",
    Slug = "equations-and-properties-of-straight-lines",
    Summary = "Explore different forms of straight line equations, calculate slopes, and analyze relationships between lines.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Straight Line"].Id,
    Title = "Applications and Practice of Straight Lines",
    Slug = "applications-and-practice-of-straight-lines",
    Summary = "Apply straight line concepts to solve coordinate geometry problems, graphing exercises, and real-world applications.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Pair of Straight Lines

new Lesson
{
    TopicId = topics["Pair of Straight Lines"].Id,
    Title = "Introduction to Pair of Straight Lines",
    Slug = "introduction-to-pair-of-straight-lines",
    Summary = "Learn the fundamentals of pair of straight lines, their equations, and how two lines can be represented together in coordinate geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Pair of Straight Lines"].Id,
    Title = "Equations and Properties of Pair of Straight Lines",
    Slug = "equations-and-properties-of-pair-of-straight-lines",
    Summary = "Explore equations of pair of straight lines, conditions for intersecting lines, and methods for solving related coordinate geometry problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Pair of Straight Lines"].Id,
    Title = "Applications and Practice of Pair of Straight Lines",
    Slug = "applications-and-practice-of-pair-of-straight-lines",
    Summary = "Apply pair of straight line concepts to solve advanced coordinate geometry problems and strengthen understanding through practice exercises.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Circle

new Lesson
{
    TopicId = topics["Circle"].Id,
    Title = "Introduction to Circle in Coordinate Geometry",
    Slug = "introduction-to-circle-in-coordinate-geometry",
    Summary = "Learn the fundamentals of circles in coordinate geometry, including center, radius, equation, and representation on the coordinate plane.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Circle"].Id,
    Title = "Equations and Properties of Circle",
    Slug = "equations-and-properties-of-circle",
    Summary = "Explore standard and general equations of circles, find centers and radii, and solve coordinate geometry problems involving circles.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Circle"].Id,
    Title = "Applications and Practice of Circle",
    Slug = "applications-and-practice-of-circle",
    Summary = "Apply circle concepts to solve advanced coordinate geometry problems involving graphs, equations, and real-world applications.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Parabola

new Lesson
{
    TopicId = topics["Parabola"].Id,
    Title = "Introduction to Parabola in Coordinate Geometry",
    Slug = "introduction-to-parabola-in-coordinate-geometry",
    Summary = "Learn the fundamentals of parabolas, their focus, directrix, vertex, and graphical representation in coordinate geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Parabola"].Id,
    Title = "Equations and Properties of Parabola",
    Slug = "equations-and-properties-of-parabola",
    Summary = "Explore standard equations of parabolas, understand their properties, and solve coordinate geometry problems involving parabolic curves.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Parabola"].Id,
    Title = "Applications and Practice of Parabola",
    Slug = "applications-and-practice-of-parabola",
    Summary = "Apply parabola concepts to solve advanced coordinate geometry problems and explore applications in physics, engineering, and design.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Ellipse

new Lesson
{
    TopicId = topics["Ellipse"].Id,
    Title = "Introduction to Ellipse in Coordinate Geometry",
    Slug = "introduction-to-ellipse-in-coordinate-geometry",
    Summary = "Learn the fundamentals of ellipses, including their focus, vertices, major and minor axes, and graphical representation in coordinate geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Ellipse"].Id,
    Title = "Equations and Properties of Ellipse",
    Slug = "equations-and-properties-of-ellipse",
    Summary = "Explore standard equations of ellipses, understand their geometric properties, and solve coordinate geometry problems involving elliptical curves.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Ellipse"].Id,
    Title = "Applications and Practice of Ellipse",
    Slug = "applications-and-practice-of-ellipse",
    Summary = "Apply ellipse concepts to solve advanced coordinate geometry problems and explore applications in astronomy, engineering, and design.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Hyperbola

new Lesson
{
    TopicId = topics["Hyperbola"].Id,
    Title = "Introduction to Hyperbola in Coordinate Geometry",
    Slug = "introduction-to-hyperbola-in-coordinate-geometry",
    Summary = "Learn the fundamentals of hyperbolas, including their focus, vertices, asymptotes, and graphical representation in coordinate geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Hyperbola"].Id,
    Title = "Equations and Properties of Hyperbola",
    Slug = "equations-and-properties-of-hyperbola",
    Summary = "Explore standard equations of hyperbolas, understand their geometric properties, and solve coordinate geometry problems involving hyperbolic curves.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Hyperbola"].Id,
    Title = "Applications and Practice of Hyperbola",
    Slug = "applications-and-practice-of-hyperbola",
    Summary = "Apply hyperbola concepts to solve advanced coordinate geometry problems and explore applications in navigation, physics, engineering, and design.",
    Content = "",
    Difficulty =DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Conic Sections

new Lesson
{
    TopicId = topics["Conic Sections"].Id,
    Title = "Introduction to Conic Sections",
    Slug = "introduction-to-conic-sections",
    Summary = "Learn the fundamentals of conic sections, including circles, parabolas, ellipses, and hyperbolas, and understand their geometric properties.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Conic Sections"].Id,
    Title = "Equations and Properties of Conic Sections",
    Slug = "equations-and-properties-of-conic-sections",
    Summary = "Explore the standard equations, characteristics, and geometric properties of different conic sections in coordinate geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Conic Sections"].Id,
    Title = "Applications and Practice of Conic Sections",
    Slug = "applications-and-practice-of-conic-sections",
    Summary = "Apply conic section concepts to solve advanced coordinate geometry problems and explore applications in engineering, astronomy, and design.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


























        };

        context.Lessons.AddRange(lessons);
        await context.SaveChangesAsync();
    }
}