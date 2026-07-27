using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class MatricesAndDeterminantsLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            // ==========================================================
// Matrix Basics
// ==========================================================

new Lesson
{
    TopicId = topics["Matrix Basics"].Id,
    Title = "Introduction to Matrix Basics",
    Slug = "introduction-to-matrix-basics",
    Summary = "Learn the fundamentals of matrices, understand rows, columns, matrix order, notation, and how matrices are used to organize numerical data.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Matrix Basics"].Id,
    Title = "Elements and Representation of Matrices",
    Slug = "elements-and-representation-of-matrices",
    Summary = "Explore matrix notation, identify matrix elements, determine matrix dimensions, and classify matrices based on their size and structure.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Matrix Basics"].Id,
    Title = "Applications and Practice of Matrix Basics",
    Slug = "applications-and-practice-of-matrix-basics",
    Summary = "Apply matrix fundamentals to solve mathematical problems and explore real-world applications in computer graphics, data science, engineering, and machine learning.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Types of Matrices
// ==========================================================

new Lesson
{
    TopicId = topics["Types of Matrices"].Id,
    Title = "Introduction to Types of Matrices",
    Slug = "introduction-to-types-of-matrices",
    Summary = "Learn the fundamentals of different types of matrices, including row, column, square, rectangular, diagonal, identity, zero, and scalar matrices.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Types of Matrices"].Id,
    Title = "Properties and Classification of Matrices",
    Slug = "properties-and-classification-of-matrices",
    Summary = "Explore the properties, characteristics, and classification of various matrix types and learn how to identify them through mathematical examples.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Types of Matrices"].Id,
    Title = "Applications and Practice of Types of Matrices",
    Slug = "applications-and-practice-of-types-of-matrices",
    Summary = "Apply different matrix types to solve mathematical problems and explore their applications in engineering, computer graphics, machine learning, cryptography, and scientific computing.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},

// ==========================================================
// Matrix Operations
// ==========================================================

new Lesson
{
    TopicId = topics["Matrix Operations"].Id,
    Title = "Introduction to Matrix Operations",
    Slug = "introduction-to-matrix-operations",
    Summary = "Learn the fundamentals of matrix operations, including matrix addition, subtraction, scalar multiplication, and matrix multiplication.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Matrix Operations"].Id,
    Title = "Performing Matrix Operations",
    Slug = "performing-matrix-operations",
    Summary = "Explore the rules, properties, and procedures for performing matrix operations, and solve problems involving matrix arithmetic step-by-step.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Matrix Operations"].Id,
    Title = "Applications and Practice of Matrix Operations",
    Slug = "applications-and-practice-of-matrix-operations",
    Summary = "Apply matrix operations to solve advanced mathematical problems and explore their applications in computer graphics, robotics, engineering, machine learning, and scientific computing.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},

// ==========================================================
// Determinants
// ==========================================================

new Lesson
{
    TopicId = topics["Determinants"].Id,
    Title = "Introduction to Determinants",
    Slug = "introduction-to-determinants",
    Summary = "Learn the fundamentals of determinants, understand how they are calculated for square matrices, and explore their significance in matrix algebra.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Determinants"].Id,
    Title = "Properties and Evaluation of Determinants",
    Slug = "properties-and-evaluation-of-determinants",
    Summary = "Explore determinant properties, cofactors, minors, expansion methods, and efficient techniques for evaluating determinants of higher-order matrices.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Determinants"].Id,
    Title = "Applications and Practice of Determinants",
    Slug = "applications-and-practice-of-determinants",
    Summary = "Apply determinant concepts to solve advanced mathematical problems and explore applications in solving linear systems, geometry, engineering, physics, and computer graphics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Inverse Matrix
// ==========================================================

new Lesson
{
    TopicId = topics["Inverse Matrix"].Id,
    Title = "Introduction to Inverse Matrix",
    Slug = "introduction-to-inverse-matrix",
    Summary = "Learn the fundamentals of inverse matrices, understand when an inverse exists, and explore its role in solving matrix equations.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Inverse Matrix"].Id,
    Title = "Finding and Verifying Inverse Matrices",
    Slug = "finding-and-verifying-inverse-matrices",
    Summary = "Explore methods for finding the inverse of a matrix using determinants, adjoints, and elementary row operations, and verify the results through matrix multiplication.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Inverse Matrix"].Id,
    Title = "Applications and Practice of Inverse Matrices",
    Slug = "applications-and-practice-of-inverse-matrices",
    Summary = "Apply inverse matrix concepts to solve systems of linear equations and explore applications in computer graphics, cryptography, engineering, machine learning, and scientific computing.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Rank of Matrix
// ==========================================================

new Lesson
{
    TopicId = topics["Rank of Matrix"].Id,
    Title = "Introduction to Rank of Matrix",
    Slug = "introduction-to-rank-of-matrix",
    Summary = "Learn the fundamentals of matrix rank, understand what rank represents, and explore its importance in linear algebra and matrix analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Rank of Matrix"].Id,
    Title = "Finding the Rank of a Matrix",
    Slug = "finding-the-rank-of-a-matrix",
    Summary = "Explore methods for determining the rank of a matrix using row reduction, echelon forms, and minors, and solve related mathematical problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Rank of Matrix"].Id,
    Title = "Applications and Practice of Matrix Rank",
    Slug = "applications-and-practice-of-matrix-rank",
    Summary = "Apply matrix rank concepts to solve systems of linear equations and explore applications in data analysis, machine learning, engineering, computer graphics, and scientific computing.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// System of Linear Equations
// ==========================================================

new Lesson
{
    TopicId = topics["System of Linear Equations"].Id,
    Title = "Introduction to Systems of Linear Equations",
    Slug = "introduction-to-systems-of-linear-equations",
    Summary = "Learn the fundamentals of systems of linear equations, understand how multiple equations represent relationships between variables, and explore their graphical interpretation.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["System of Linear Equations"].Id,
    Title = "Solving Systems of Linear Equations",
    Slug = "solving-systems-of-linear-equations",
    Summary = "Explore methods for solving systems of linear equations using substitution, elimination, matrices, and Cramer's Rule, and interpret different types of solutions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["System of Linear Equations"].Id,
    Title = "Applications and Practice of Systems of Linear Equations",
    Slug = "applications-and-practice-of-systems-of-linear-equations",
    Summary = "Apply systems of linear equations to solve advanced mathematical problems and explore applications in economics, engineering, operations research, computer science, and data analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Eigenvalues
// ==========================================================

new Lesson
{
    TopicId = topics["Eigenvalues"].Id,
    Title = "Introduction to Eigenvalues",
    Slug = "introduction-to-eigenvalues",
    Summary = "Learn the fundamentals of eigenvalues and understand how they describe important properties of matrix transformations and linear systems.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Eigenvalues"].Id,
    Title = "Finding Eigenvalues and Eigenvectors",
    Slug = "finding-eigenvalues-and-eigenvectors",
    Summary = "Explore characteristic equations, calculate eigenvalues and corresponding eigenvectors, and solve problems involving matrix transformations.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Eigenvalues"].Id,
    Title = "Applications and Practice of Eigenvalues",
    Slug = "applications-and-practice-of-eigenvalues",
    Summary = "Apply eigenvalue concepts to solve advanced mathematical problems and explore applications in machine learning, computer graphics, vibration analysis, quantum mechanics, and data science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Eigenvectors
// ==========================================================

new Lesson
{
    TopicId = topics["Eigenvectors"].Id,
    Title = "Introduction to Eigenvectors",
    Slug = "introduction-to-eigenvectors",
    Summary = "Learn the fundamentals of eigenvectors and understand how they represent directions that remain unchanged under matrix transformations.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Eigenvectors"].Id,
    Title = "Finding and Analyzing Eigenvectors",
    Slug = "finding-and-analyzing-eigenvectors",
    Summary = "Explore methods for calculating eigenvectors corresponding to eigenvalues, verify solutions, and understand their geometric interpretation.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Eigenvectors"].Id,
    Title = "Applications and Practice of Eigenvectors",
    Slug = "applications-and-practice-of-eigenvectors",
    Summary = "Apply eigenvector concepts to solve advanced mathematical problems and explore applications in machine learning, facial recognition, principal component analysis (PCA), computer graphics, engineering, and quantum physics.",
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