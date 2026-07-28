
// Complex Numbers Lesson Seeder


using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class ComplexNumbersLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            
// Imaginary Numbers


new Lesson
{
    TopicId = topics["Imaginary Numbers"].Id,
    Title = "Introduction to Imaginary Numbers",
    Slug = "introduction-to-imaginary-numbers",
    Summary = "Learn the fundamentals of imaginary numbers, understand why they were introduced, and explore how they extend the number system beyond real numbers.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Imaginary Numbers"].Id,
    Title = "Operations with Imaginary Numbers",
    Slug = "operations-with-imaginary-numbers",
    Summary = "Explore arithmetic operations involving imaginary numbers, including addition, subtraction, multiplication, division, and powers of the imaginary unit.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Imaginary Numbers"].Id,
    Title = "Applications and Practice of Imaginary Numbers",
    Slug = "applications-and-practice-of-imaginary-numbers",
    Summary = "Apply imaginary number concepts to solve advanced mathematical problems and explore their applications in electrical engineering, signal processing, physics, and complex mathematical systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Complex Plane


new Lesson
{
    TopicId = topics["Complex Plane"].Id,
    Title = "Introduction to the Complex Plane",
    Slug = "introduction-to-the-complex-plane",
    Summary = "Learn the fundamentals of the complex plane, understand how complex numbers are represented geometrically, and explore the relationship between real and imaginary components.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Complex Plane"].Id,
    Title = "Plotting and Operations on the Complex Plane",
    Slug = "plotting-and-operations-on-the-complex-plane",
    Summary = "Explore how to represent complex numbers on a coordinate plane, calculate magnitude and direction, and perform geometric interpretations of complex number operations.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Complex Plane"].Id,
    Title = "Applications and Practice of the Complex Plane",
    Slug = "applications-and-practice-of-the-complex-plane",
    Summary = "Apply complex plane concepts to solve advanced problems and explore applications in geometry, physics, electronics, signal processing, engineering, and computer graphics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Polar Form


new Lesson
{
    TopicId = topics["Polar Form"].Id,
    Title = "Introduction to Polar Form of Complex Numbers",
    Slug = "introduction-to-polar-form-of-complex-numbers",
    Summary = "Learn the fundamentals of polar form, understand how complex numbers can be represented using magnitude and angle, and explore the connection between rectangular and polar representations.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Polar Form"].Id,
    Title = "Converting and Operating with Polar Form",
    Slug = "converting-and-operating-with-polar-form",
    Summary = "Explore conversions between rectangular and polar forms, multiplication and division of complex numbers in polar form, and geometric interpretations using magnitude and arguments.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Polar Form"].Id,
    Title = "Applications and Practice of Polar Form",
    Slug = "applications-and-practice-of-polar-form",
    Summary = "Apply polar form concepts to solve advanced complex number problems and explore applications in electrical engineering, signal processing, physics, rotations, and mathematical modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Modulus & Argument


new Lesson
{
    TopicId = topics["Modulus & Argument"].Id,
    Title = "Introduction to Modulus and Argument",
    Slug = "introduction-to-modulus-and-argument",
    Summary = "Learn the fundamentals of modulus and argument of complex numbers, understand their geometric meaning, and explore how they describe magnitude and direction on the complex plane.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Modulus & Argument"].Id,
    Title = "Calculating Modulus and Argument",
    Slug = "calculating-modulus-and-argument",
    Summary = "Explore methods for finding the modulus and argument of complex numbers, understand angle calculations, and learn how these concepts connect rectangular and polar forms.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Modulus & Argument"].Id,
    Title = "Applications and Practice of Modulus and Argument",
    Slug = "applications-and-practice-of-modulus-and-argument",
    Summary = "Apply modulus and argument concepts to solve advanced complex number problems and explore applications in geometry, rotations, electrical engineering, signal processing, and mathematical modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// De Moivre's Theorem


new Lesson
{
    TopicId = topics["De Moivre's Theorem"].Id,
    Title = "Introduction to De Moivre's Theorem",
    Slug = "introduction-to-de-moivres-theorem",
    Summary = "Learn the fundamentals of De Moivre's Theorem, understand its connection with complex numbers in polar form, and explore how powers of complex numbers can be simplified.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["De Moivre's Theorem"].Id,
    Title = "Using De Moivre's Theorem",
    Slug = "using-de-moivres-theorem",
    Summary = "Explore how to apply De Moivre's Theorem for calculating powers, roots, and trigonometric relationships of complex numbers in polar form.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["De Moivre's Theorem"].Id,
    Title = "Applications and Practice of De Moivre's Theorem",
    Slug = "applications-and-practice-of-de-moivres-theorem",
    Summary = "Apply De Moivre's Theorem to solve advanced complex number problems and explore applications in engineering, physics, signal processing, wave analysis, and mathematical transformations.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Roots of Complex Numbers


new Lesson
{
    TopicId = topics["Roots of Complex Numbers"].Id,
    Title = "Introduction to Roots of Complex Numbers",
    Slug = "introduction-to-roots-of-complex-numbers",
    Summary = "Learn the fundamentals of finding roots of complex numbers, understand the geometric meaning of roots, and explore how complex numbers can have multiple solutions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Roots of Complex Numbers"].Id,
    Title = "Finding Roots Using Polar Form",
    Slug = "finding-roots-using-polar-form",
    Summary = "Explore methods for calculating roots of complex numbers using polar representation, De Moivre's Theorem, and arguments to find all possible solutions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Roots of Complex Numbers"].Id,
    Title = "Applications and Practice of Complex Roots",
    Slug = "applications-and-practice-of-complex-roots",
    Summary = "Apply complex root techniques to solve advanced mathematical problems and explore applications in engineering, signal processing, quantum physics, rotations, and mathematical transformations.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Complex Functions


new Lesson
{
    TopicId = topics["Complex Functions"].Id,
    Title = "Introduction to Complex Functions",
    Slug = "introduction-to-complex-functions",
    Summary = "Learn the fundamentals of complex functions, understand mappings between complex numbers, and explore how functions extend mathematical ideas into the complex domain.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Complex Functions"].Id,
    Title = "Properties and Transformations of Complex Functions",
    Slug = "properties-and-transformations-of-complex-functions",
    Summary = "Explore complex mappings, transformations, analytic functions, continuity, and the behaviour of functions involving complex variables.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Complex Functions"].Id,
    Title = "Applications and Practice of Complex Functions",
    Slug = "applications-and-practice-of-complex-functions",
    Summary = "Apply complex function concepts to solve advanced mathematical problems and explore applications in physics, engineering, fluid dynamics, signal processing, quantum mechanics, and computer science.",
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