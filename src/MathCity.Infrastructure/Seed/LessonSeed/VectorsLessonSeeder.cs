using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class VectorsLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            // ==========================================================
// Vector Basics
// ==========================================================

new Lesson
{
    TopicId = topics["Vector Basics"].Id,
    Title = "Introduction to Vector Basics",
    Slug = "introduction-to-vector-basics",
    Summary = "Learn the fundamentals of vectors, understand magnitude and direction, and explore how vectors differ from scalar quantities.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Vector Basics"].Id,
    Title = "Representation and Components of Vectors",
    Slug = "representation-and-components-of-vectors",
    Summary = "Explore different ways to represent vectors, resolve vectors into components, and perform basic vector calculations in two and three dimensions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Vector Basics"].Id,
    Title = "Applications and Practice of Vector Basics",
    Slug = "applications-and-practice-of-vector-basics",
    Summary = "Apply vector fundamentals to solve mathematical problems and explore real-world applications in physics, engineering, robotics, computer graphics, navigation, and artificial intelligence.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Vector Operations
// ==========================================================

new Lesson
{
    TopicId = topics["Vector Operations"].Id,
    Title = "Introduction to Vector Operations",
    Slug = "introduction-to-vector-operations",
    Summary = "Learn the fundamentals of vector operations, including vector addition, subtraction, scalar multiplication, and basic vector arithmetic.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Vector Operations"].Id,
    Title = "Performing Vector Operations",
    Slug = "performing-vector-operations",
    Summary = "Explore methods for performing vector addition, subtraction, scalar multiplication, and graphical and analytical vector calculations.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Vector Operations"].Id,
    Title = "Applications and Practice of Vector Operations",
    Slug = "applications-and-practice-of-vector-operations",
    Summary = "Apply vector operation concepts to solve advanced mathematical problems and explore applications in physics, engineering, robotics, computer graphics, navigation, and artificial intelligence.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Dot Product
// ==========================================================

new Lesson
{
    TopicId = topics["Dot Product"].Id,
    Title = "Introduction to Dot Product",
    Slug = "introduction-to-dot-product",
    Summary = "Learn the fundamentals of the dot product, understand how it combines two vectors into a scalar value, and explore its geometric meaning.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Dot Product"].Id,
    Title = "Calculating and Interpreting Dot Product",
    Slug = "calculating-and-interpreting-dot-product",
    Summary = "Explore methods for calculating the dot product using vector components and angles, and understand its relationship to vector length and orthogonality.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Dot Product"].Id,
    Title = "Applications and Practice of Dot Product",
    Slug = "applications-and-practice-of-dot-product",
    Summary = "Apply dot product concepts to solve advanced vector problems and explore applications in physics, computer graphics, machine learning, robotics, engineering, and navigation.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Cross Product
// ==========================================================

new Lesson
{
    TopicId = topics["Cross Product"].Id,
    Title = "Introduction to Cross Product",
    Slug = "introduction-to-cross-product",
    Summary = "Learn the fundamentals of the cross product, understand how it produces a vector perpendicular to two given vectors, and explore its geometric significance.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Cross Product"].Id,
    Title = "Calculating and Interpreting Cross Product",
    Slug = "calculating-and-interpreting-cross-product",
    Summary = "Explore methods for calculating the cross product using vector components, determine vector direction with the right-hand rule, and solve related vector problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Cross Product"].Id,
    Title = "Applications and Practice of Cross Product",
    Slug = "applications-and-practice-of-cross-product",
    Summary = "Apply cross product concepts to solve advanced vector problems and explore applications in physics, engineering, robotics, computer graphics, mechanics, and 3D modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Projection
// ==========================================================

new Lesson
{
    TopicId = topics["Projection"].Id,
    Title = "Introduction to Vector Projection",
    Slug = "introduction-to-vector-projection",
    Summary = "Learn the fundamentals of vector projection, understand how one vector is projected onto another, and explore its geometric interpretation.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Projection"].Id,
    Title = "Calculating Vector Projection",
    Slug = "calculating-vector-projection",
    Summary = "Explore formulas for scalar and vector projection, calculate projections using the dot product, and solve projection problems step-by-step.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Projection"].Id,
    Title = "Applications and Practice of Vector Projection",
    Slug = "applications-and-practice-of-vector-projection",
    Summary = "Apply vector projection concepts to solve advanced mathematical problems and explore applications in physics, engineering, robotics, computer graphics, navigation, and machine learning.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Direction Cosines
// ==========================================================

new Lesson
{
    TopicId = topics["Direction Cosines"].Id,
    Title = "Introduction to Direction Cosines",
    Slug = "introduction-to-direction-cosines",
    Summary = "Learn the fundamentals of direction cosines, understand how they describe the orientation of a vector in three-dimensional space, and explore their geometric meaning.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Direction Cosines"].Id,
    Title = "Calculating Direction Cosines and Ratios",
    Slug = "calculating-direction-cosines-and-ratios",
    Summary = "Explore methods for finding direction cosines and direction ratios of vectors, verify their properties, and solve three-dimensional vector problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Direction Cosines"].Id,
    Title = "Applications and Practice of Direction Cosines",
    Slug = "applications-and-practice-of-direction-cosines",
    Summary = "Apply direction cosine concepts to solve advanced three-dimensional geometry problems and explore applications in physics, engineering, robotics, navigation, aerospace, and computer graphics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Lines in Space
// ==========================================================

new Lesson
{
    TopicId = topics["Lines in Space"].Id,
    Title = "Introduction to Lines in Space",
    Slug = "introduction-to-lines-in-space",
    Summary = "Learn the fundamentals of lines in three-dimensional space, understand vector and parametric equations, and explore how lines are represented using vectors.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Lines in Space"].Id,
    Title = "Equations and Relationships of Lines in Space",
    Slug = "equations-and-relationships-of-lines-in-space",
    Summary = "Explore vector, parametric, and symmetric equations of lines, determine angles between lines, and identify parallel, intersecting, and skew lines.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Lines in Space"].Id,
    Title = "Applications and Practice of Lines in Space",
    Slug = "applications-and-practice-of-lines-in-space",
    Summary = "Apply three-dimensional line concepts to solve advanced geometry problems and explore applications in engineering, robotics, computer graphics, architecture, navigation, and physics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Planes
// ==========================================================

new Lesson
{
    TopicId = topics["Planes"].Id,
    Title = "Introduction to Planes",
    Slug = "introduction-to-planes",
    Summary = "Learn the fundamentals of planes in three-dimensional space, understand their geometric representation, and explore how planes are defined using points and vectors.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Planes"].Id,
    Title = "Equations and Properties of Planes",
    Slug = "equations-and-properties-of-planes",
    Summary = "Explore vector, normal, and Cartesian equations of planes, determine angles and distances, and analyze relationships between planes and lines in space.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Planes"].Id,
    Title = "Applications and Practice of Planes",
    Slug = "applications-and-practice-of-planes",
    Summary = "Apply plane geometry concepts to solve advanced three-dimensional problems and explore applications in engineering, architecture, computer graphics, robotics, navigation, and physics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},


        };

        await context.Lessons.AddRangeAsync(lessons);
        await context.SaveChangesAsync();
    }
}