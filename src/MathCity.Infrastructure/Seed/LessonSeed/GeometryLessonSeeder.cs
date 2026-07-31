using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class GeometryLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {

        if (await context.Lessons.AnyAsync())
            return;
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {

            
            // Points, Lines & Angles
            

            new Lesson
            {
                TopicId = topics["Points, Lines & Angles"].Id,
                Title = "Introduction to Points, Lines & Angles",
                Slug = "introduction-to-points-lines-and-angles",
                Summary = "Learn the fundamental concepts of points, lines, rays, line segments, and angles that form the basis of geometry.",
                Content = "",
                Difficulty = DifficultyLevel.Begineer,
                ReadingTimeMinutes = 10,
                IsPublished = true,
                DisplayOrder = 1,
                
            },

            new Lesson
            {
                TopicId = topics["Points, Lines & Angles"].Id,
                Title = "Types of Points, Lines & Angles",
                Slug = "types-of-points-lines-and-angles",
                Summary = "Explore different types of lines, angle classifications, and relationships between geometric figures.",
                Content = "",
                Difficulty = DifficultyLevel.Intermediate,
                ReadingTimeMinutes = 15,
                IsPublished = true,
                DisplayOrder = 2,
                
            },

            new Lesson
            {
                TopicId = topics["Points, Lines & Angles"].Id,
                Title = "Applications of Points, Lines & Angles",
                Slug = "applications-of-points-lines-and-angles",
                Summary = "Discover how points, lines, and angles are applied in architecture, engineering, navigation, and everyday geometry.",
                Content = "",
                Difficulty = DifficultyLevel.Advance,
                ReadingTimeMinutes = 20,
                IsPublished = true,
                DisplayOrder = 3,
                
            },
            
// Triangles


new Lesson
{
    TopicId = topics["Triangles"].Id,
    Title = "Introduction to Triangles",
    Slug = "introduction-to-triangles",
    Summary = "Learn what triangles are, understand their basic properties, elements, and why they are one of the most fundamental shapes in geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Triangles"].Id,
    Title = "Types of Triangles",
    Slug = "types-of-triangles",
    Summary = "Explore the different types of triangles based on their sides and angles, and learn how each type is identified.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Triangles"].Id,
    Title = "Applications of Triangles",
    Slug = "applications-of-triangles",
    Summary = "Discover how triangles are used in engineering, architecture, surveying, navigation, computer graphics, and everyday life.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Congruence


new Lesson
{
    TopicId = topics["Congruence"].Id,
    Title = "Introduction to Congruence",
    Slug = "introduction-to-congruence",
    Summary = "Learn the concept of congruence, understand when two geometric figures are congruent, and explore the significance of equal shape and size.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Congruence"].Id,
    Title = "Congruence Criteria",
    Slug = "congruence-criteria",
    Summary = "Explore the different criteria used to prove congruence, including SSS, SAS, ASA, AAS, and RHS for triangles.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Congruence"].Id,
    Title = "Applications of Congruence",
    Slug = "applications-of-congruence",
    Summary = "Discover how congruence is applied in engineering, architecture, manufacturing, surveying, and geometric problem-solving.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
}, 


// Similarity


new Lesson
{
    TopicId = topics["Similarity"].Id,
    Title = "Introduction to Similarity",
    Slug = "introduction-to-similarity",
    Summary = "Learn the concept of similarity, understand how geometric figures can have the same shape but different sizes, and explore their fundamental properties.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Similarity"].Id,
    Title = "Similarity Criteria",
    Slug = "similarity-criteria",
    Summary = "Explore the criteria used to determine the similarity of figures, including AA, SAS, and SSS similarity for triangles.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Similarity"].Id,
    Title = "Applications of Similarity",
    Slug = "applications-of-similarity",
    Summary = "Discover how similarity is applied in architecture, surveying, map scaling, photography, engineering, and computer graphics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Quadrilaterals


new Lesson
{
    TopicId = topics["Quadrilaterals"].Id,
    Title = "Introduction to Quadrilaterals",
    Slug = "introduction-to-quadrilaterals",
    Summary = "Learn what quadrilaterals are, understand their properties, and explore the different four-sided shapes found in geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Quadrilaterals"].Id,
    Title = "Types of Quadrilaterals",
    Slug = "types-of-quadrilaterals",
    Summary = "Explore the different types of quadrilaterals, including squares, rectangles, parallelograms, rhombuses, trapeziums, and kites, along with their unique properties.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Quadrilaterals"].Id,
    Title = "Applications of Quadrilaterals",
    Slug = "applications-of-quadrilaterals",
    Summary = "Discover how quadrilaterals are used in architecture, engineering, surveying, construction, computer graphics, and everyday design.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Polygons


new Lesson
{
    TopicId = topics["Polygons"].Id,
    Title = "Introduction to Polygons",
    Slug = "introduction-to-polygons",
    Summary = "Learn what polygons are, understand their basic properties, and explore the characteristics of closed plane figures with straight sides.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Polygons"].Id,
    Title = "Types of Polygons",
    Slug = "types-of-polygons",
    Summary = "Explore different types of polygons based on the number of sides, regular and irregular polygons, and convex and concave polygons.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Polygons"].Id,
    Title = "Applications of Polygons",
    Slug = "applications-of-polygons",
    Summary = "Discover how polygons are used in architecture, engineering, computer graphics, design, mapping, and everyday geometric structures.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Circles


new Lesson
{
    TopicId = topics["Circles"].Id,
    Title = "Introduction to Circles",
    Slug = "introduction-to-circles",
    Summary = "Learn what circles are, understand their fundamental properties, and explore the basic terminology used to describe circular shapes.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Circles"].Id,
    Title = "Parts and Properties of Circles",
    Slug = "parts-and-properties-of-circles",
    Summary = "Explore the key parts of a circle, including the center, radius, diameter, chord, arc, sector, segment, tangent, and secant, along with their geometric properties.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Circles"].Id,
    Title = "Applications of Circles",
    Slug = "applications-of-circles",
    Summary = "Discover how circles are used in engineering, architecture, transportation, astronomy, mechanical design, computer graphics, and everyday life.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Constructions


new Lesson
{
    TopicId = topics["Constructions"].Id,
    Title = "Introduction to Geometric Constructions",
    Slug = "introduction-to-geometric-constructions",
    Summary = "Learn the fundamentals of geometric constructions, understand the use of a compass and straightedge, and explore why constructions are important in geometry.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Constructions"].Id,
    Title = "Common Geometric Constructions",
    Slug = "common-geometric-constructions",
    Summary = "Explore essential geometric constructions such as bisecting angles, drawing perpendicular and parallel lines, constructing triangles, and dividing line segments.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Constructions"].Id,
    Title = "Applications of Geometric Constructions",
    Slug = "applications-of-geometric-constructions",
    Summary = "Discover how geometric constructions are used in architecture, engineering, surveying, technical drawing, design, and computer-aided modeling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Area


new Lesson
{
    TopicId = topics["Area"].Id,
    Title = "Introduction to Area",
    Slug = "introduction-to-area",
    Summary = "Learn the concept of area, understand how it measures the space enclosed by two-dimensional shapes, and explore its units of measurement.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Area"].Id,
    Title = "Area of Common Shapes",
    Slug = "area-of-common-shapes",
    Summary = "Explore how to calculate the area of common geometric figures such as squares, rectangles, triangles, parallelograms, trapeziums, circles, and polygons.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Area"].Id,
    Title = "Applications of Area",
    Slug = "applications-of-area",
    Summary = "Discover how area is used in architecture, engineering, construction, agriculture, mapping, computer graphics, and everyday problem-solving.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Perimeter


new Lesson
{
    TopicId = topics["Perimeter"].Id,
    Title = "Introduction to Perimeter",
    Slug = "introduction-to-perimeter",
    Summary = "Learn the concept of perimeter, understand how it measures the total distance around a two-dimensional shape, and explore its units of measurement.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Perimeter"].Id,
    Title = "Calculating the Perimeter of Shapes",
    Slug = "calculating-the-perimeter-of-shapes",
    Summary = "Explore methods for calculating the perimeter of common geometric figures such as squares, rectangles, triangles, circles, and other polygons.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Perimeter"].Id,
    Title = "Applications of Perimeter",
    Slug = "applications-of-perimeter",
    Summary = "Discover how perimeter is applied in construction, landscaping, fencing, architecture, engineering, manufacturing, and everyday measurement problems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Transformations


new Lesson
{
    TopicId = topics["Transformations"].Id,
    Title = "Introduction to Transformations",
    Slug = "introduction-to-transformations",
    Summary = "Learn the fundamentals of geometric transformations, understand how shapes can be moved, reflected, rotated, and resized while preserving or changing their properties.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Transformations"].Id,
    Title = "Types of Transformations",
    Slug = "types-of-transformations",
    Summary = "Explore the four fundamental geometric transformations—translation, reflection, rotation, and dilation—and understand how each affects the position, orientation, and size of a figure.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Transformations"].Id,
    Title = "Applications of Transformations",
    Slug = "applications-of-transformations",
    Summary = "Discover how geometric transformations are applied in computer graphics, animation, robotics, engineering, architecture, image processing, and game development.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},


// Coordinate Proofs


new Lesson
{
    TopicId = topics["Coordinate Proofs"].Id,
    Title = "Introduction to Coordinate Proofs",
    Slug = "introduction-to-coordinate-proofs",
    Summary = "Learn the fundamentals of coordinate proofs, understand how algebra and geometry work together, and explore how geometric properties can be proven using coordinates.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Coordinate Proofs"].Id,
    Title = "Methods of Coordinate Proofs",
    Slug = "methods-of-coordinate-proofs",
    Summary = "Explore common techniques used in coordinate proofs, including the distance formula, midpoint formula, slope, and equations of lines to verify geometric relationships.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Coordinate Proofs"].Id,
    Title = "Applications of Coordinate Proofs",
    Slug = "applications-of-coordinate-proofs",
    Summary = "Discover how coordinate proofs are used in engineering, architecture, computer graphics, robotics, surveying, and analytical problem-solving.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
























        };

        foreach (var lesson in lessons)
        {
            var existing = await context.Lessons.FirstOrDefaultAsync(x =>
                x.TopicId == lesson.TopicId &&
                x.Title == lesson.Title);

            if (existing == null)
            {
                context.Lessons.Add(lesson);
                continue;
            }

            existing.Slug = lesson.Slug;
            existing.Summary = lesson.Summary;
            existing.Content = lesson.Content;
            existing.Difficulty = lesson.Difficulty;
            existing.ReadingTimeMinutes = lesson.ReadingTimeMinutes;
            existing.IsPublished = lesson.IsPublished;
            existing.DisplayOrder = lesson.DisplayOrder;
        }

        await context.SaveChangesAsync();
    }
}