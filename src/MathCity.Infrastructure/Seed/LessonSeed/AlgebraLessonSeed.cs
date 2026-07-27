using Microsoft.EntityFrameworkCore;
using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;

public static class AlgebraLessonSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Lessons.Any())
            return;

        var topics = await context.Topics.ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>();

       
        // Algebraic Expressions
        lessons.AddRange(new[]
        {
            new Lesson
            {
                TopicId = topics["Algebraic Expressions"].Id,
                Title = "Introduction to Algebraic Expressions",
                Slug = "introduction-to-algebraic-expressions",
                Summary = "Understand the fundamentals of algebraic expressions, including variables, constants, coefficients, and terms.",
                Content = "",
                Difficulty = DifficultyLevel.Begineer,
                ReadingTimeMinutes = 10,
                IsPublished = true,
                DisplayOrder = 1,
                ThumbnailUrl = ""
            },

            new Lesson
            {
                TopicId = topics["Algebraic Expressions"].Id,
                Title = "Simplifying and Evaluating Algebraic Expressions",
                Slug = "simplifying-and-evaluating-algebraic-expressions",
                Summary = "Learn techniques to simplify algebraic expressions and evaluate them using given variable values.",
                Content = "",
                Difficulty = DifficultyLevel.Begineer,
                ReadingTimeMinutes = 15,
                IsPublished = true,
                DisplayOrder = 2,
                ThumbnailUrl = ""
            },

            new Lesson
            {
                TopicId = topics["Algebraic Expressions"].Id,
                Title = "Applications and Practice of Algebraic Expressions",
                Slug = "applications-and-practice-of-algebraic-expressions",
                Summary = "Apply algebraic expressions to solve mathematical and real-world problems through guided practice.",
                Content = "",
                Difficulty = DifficultyLevel.Begineer,
                ReadingTimeMinutes = 20,
                IsPublished = true,
                DisplayOrder = 3,
                ThumbnailUrl = ""
            },

    new Lesson
    {
        TopicId = topics["Linear Equations"].Id,
        Title = "Introduction to Linear Equations",
        Slug = "introduction-to-linear-equations",
        Summary = "Learn what linear equations are, their standard form, and how they model relationships between variables.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Linear Equations"].Id,
        Title = "Solving Linear Equations",
        Slug = "solving-linear-equations",
        Summary = "Master techniques for solving one-variable linear equations using inverse operations and balancing methods.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 15,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Linear Equations"].Id,
        Title = "Applications and Practice of Linear Equations",
        Slug = "applications-and-practice-of-linear-equations",
        Summary = "Apply linear equations to solve practical problems and reinforce learning through worked examples and practice exercises.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 20,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },





// Simultaneous Equations

    new Lesson
    {
        TopicId = topics["Simultaneous Equations"].Id,
        Title = "Introduction to Simultaneous Equations",
        Slug = "introduction-to-simultaneous-equations",
        Summary = "Understand simultaneous equations, why they are used, and how multiple equations can be solved together to find unknown values.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Simultaneous Equations"].Id,
        Title = "Methods for Solving Simultaneous Equations",
        Slug = "methods-for-solving-simultaneous-equations",
        Summary = "Learn substitution, elimination, and graphical methods to solve systems of simultaneous equations efficiently.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 15,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Simultaneous Equations"].Id,
        Title = "Applications and Practice of Simultaneous Equations",
        Slug = "applications-and-practice-of-simultaneous-equations",
        Summary = "Solve real-world problems involving simultaneous equations and strengthen your understanding through guided practice.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 20,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },




    // inequalities
     new Lesson
    {
        TopicId = topics["Inequalities"].Id,
        Title = "Introduction to Inequalities",
        Slug = "introduction-to-inequalities",
        Summary = "Learn what inequalities are, the different inequality symbols, and how they compare quantities using mathematical expressions.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Inequalities"].Id,
        Title = "Solving and Graphing Inequalities",
        Slug = "solving-and-graphing-inequalities",
        Summary = "Master techniques for solving linear inequalities, representing solutions on a number line, and understanding interval notation.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 15,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Inequalities"].Id,
        Title = "Applications and Practice of Inequalities",
        Slug = "applications-and-practice-of-inequalities",
        Summary = "Apply inequalities to solve real-world problems involving limits, ranges, and constraints through guided examples and practice.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 20,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },


    // Quadratic Equations




    new Lesson
    {
        TopicId = topics["Quadratic Equations"].Id,
        Title = "Introduction to Quadratic Equations",
        Slug = "introduction-to-quadratic-equations",
        Summary = "Learn the fundamentals of quadratic equations, their standard form, key terminology, and how they differ from linear equations.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Quadratic Equations"].Id,
        Title = "Methods for Solving Quadratic Equations",
        Slug = "methods-for-solving-quadratic-equations",
        Summary = "Explore various techniques for solving quadratic equations, including factorization, completing the square, and the quadratic formula.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Quadratic Equations"].Id,
        Title = "Applications and Practice of Quadratic Equations",
        Slug = "applications-and-practice-of-quadratic-equations",
        Summary = "Apply quadratic equations to real-world situations, analyze their graphs, and reinforce learning through worked examples and practice problems.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },

   
// Polynomials


    new Lesson
    {
        TopicId = topics["Polynomials"].Id,
        Title = "Introduction to Polynomials",
        Slug = "introduction-to-polynomials",
        Summary = "Learn what polynomials are, their standard form, different types, and the terminology used to describe them.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Polynomials"].Id,
        Title = "Polynomial Operations and Factorization",
        Slug = "polynomial-operations-and-factorization",
        Summary = "Master addition, subtraction, multiplication, division, and factorization techniques for working with polynomial expressions.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Polynomials"].Id,
        Title = "Applications and Practice of Polynomials",
        Slug = "applications-and-practice-of-polynomials",
        Summary = "Apply polynomial concepts to solve mathematical problems, analyze polynomial functions, and reinforce learning through guided practice.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },

// Factorization

    new Lesson
    {
        TopicId = topics["Factorization"].Id,
        Title = "Introduction to Factorization",
        Slug = "introduction-to-factorization",
        Summary = "Learn the fundamentals of factorization, why it is important, and how expressions can be rewritten as products of simpler factors.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Factorization"].Id,
        Title = "Methods of Factorization",
        Slug = "methods-of-factorization",
        Summary = "Master common factor extraction, grouping, identities, difference of squares, and factorization of quadratic expressions.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Factorization"].Id,
        Title = "Applications and Practice of Factorization",
        Slug = "applications-and-practice-of-factorization",
        Summary = "Use factorization to simplify expressions, solve equations, and strengthen your understanding through worked examples and practice exercises.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },
// Rational Expressions
    new Lesson
    {
        TopicId = topics["Rational Expressions"].Id,
        Title = "Introduction to Rational Expressions",
        Slug = "introduction-to-rational-expressions",
        Summary = "Learn what rational expressions are, their structure, domain restrictions, and how they relate to fractions.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Rational Expressions"].Id,
        Title = "Simplifying and Operating on Rational Expressions",
        Slug = "simplifying-and-operating-on-rational-expressions",
        Summary = "Master simplifying rational expressions and perform addition, subtraction, multiplication, and division using algebraic techniques.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Rational Expressions"].Id,
        Title = "Applications and Practice of Rational Expressions",
        Slug = "applications-and-practice-of-rational-expressions",
        Summary = "Apply rational expressions to solve equations and real-world problems while reinforcing concepts through guided practice.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },

   
// Exponents

    new Lesson
    {
        TopicId = topics["Exponents"].Id,
        Title = "Introduction to Exponents",
        Slug = "introduction-to-exponents",
        Summary = "Understand the concept of exponents, powers, bases, and how repeated multiplication is represented using exponential notation.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Exponents"].Id,
        Title = "Laws and Operations of Exponents",
        Slug = "laws-and-operations-of-exponents",
        Summary = "Master the laws of exponents, including multiplication, division, powers of powers, zero exponents, and negative exponents.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Exponents"].Id,
        Title = "Applications and Practice of Exponents",
        Slug = "applications-and-practice-of-exponents",
        Summary = "Apply exponent rules to solve mathematical problems and explore real-world applications such as scientific notation and exponential growth.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },

// Radicals (Surds)




    new Lesson
    {
        TopicId = topics["Radicals (Surds)"].Id,
        Title = "Introduction to Radicals and Surds",
        Slug = "introduction-to-radicals-and-surds",
        Summary = "Learn the fundamentals of radicals and surds, understand square roots, cube roots, and identify irrational numbers expressed as surds.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Radicals (Surds)"].Id,
        Title = "Simplifying and Operating on Radicals",
        Slug = "simplifying-and-operating-on-radicals",
        Summary = "Master techniques for simplifying radicals and performing addition, subtraction, multiplication, division, and rationalizing denominators.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Radicals (Surds)"].Id,
        Title = "Applications and Practice of Radicals and Surds",
        Slug = "applications-and-practice-of-radicals-and-surds",
        Summary = "Apply radicals and surds to solve algebraic and geometric problems while strengthening understanding through worked examples and practice exercises.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    }, 
// Logarithms
    new Lesson
    {
        TopicId = topics["Logarithms"].Id,
        Title = "Introduction to Logarithms",
        Slug = "introduction-to-logarithms",
        Summary = "Understand the concept of logarithms, their relationship with exponents, and how logarithmic notation is used to solve mathematical problems.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Logarithms"].Id,
        Title = "Laws and Properties of Logarithms",
        Slug = "laws-and-properties-of-logarithms",
        Summary = "Master the fundamental laws of logarithms, including product, quotient, and power rules, and learn how to simplify logarithmic expressions.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Logarithms"].Id,
        Title = "Applications and Practice of Logarithms",
        Slug = "applications-and-practice-of-logarithms",
        Summary = "Apply logarithmic concepts to solve exponential equations and explore practical applications through worked examples and practice exercises.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },
    
// Absolute Value




    new Lesson
    {
        TopicId = topics["Absolute Value"].Id,
        Title = "Introduction to Absolute Value",
        Slug = "introduction-to-absolute-value",
        Summary = "Learn the concept of absolute value as the distance of a number from zero, understand its notation, and explore its fundamental properties.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Absolute Value"].Id,
        Title = "Operations and Equations with Absolute Value",
        Slug = "operations-and-equations-with-absolute-value",
        Summary = "Master operations involving absolute values and learn systematic methods for solving absolute value equations and inequalities.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Absolute Value"].Id,
        Title = "Applications and Practice of Absolute Value",
        Slug = "applications-and-practice-of-absolute-value",
        Summary = "Apply absolute value concepts to solve mathematical and real-world problems involving distance, error, and measurement through guided practice.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    },
   
// Algebraic Identities

    new Lesson
    {
        TopicId = topics["Algebraic Identities"].Id,
        Title = "Introduction to Algebraic Identities",
        Slug = "introduction-to-algebraic-identities",
        Summary = "Learn what algebraic identities are, understand their significance, and explore the most commonly used identities in algebra.",
        Content = "",
        Difficulty = DifficultyLevel.Begineer,
        ReadingTimeMinutes = 10,
        IsPublished = true,
        DisplayOrder = 1,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Algebraic Identities"].Id,
        Title = "Applying Algebraic Identities",
        Slug = "applying-algebraic-identities",
        Summary = "Master the application of algebraic identities to expand, simplify, and factor algebraic expressions efficiently.",
        Content = "",
        Difficulty = DifficultyLevel.Intermediate,
        ReadingTimeMinutes = 18,
        IsPublished = true,
        DisplayOrder = 2,
        ThumbnailUrl = ""
    },

    new Lesson
    {
        TopicId = topics["Algebraic Identities"].Id,
        Title = "Applications and Practice of Algebraic Identities",
        Slug = "applications-and-practice-of-algebraic-identities",
        Summary = "Apply algebraic identities to solve equations, simplify complex expressions, and reinforce understanding through worked examples and practice exercises.",
        Content = "",
        Difficulty = DifficultyLevel.Advance,
        ReadingTimeMinutes = 22,
        IsPublished = true,
        DisplayOrder = 3,
        ThumbnailUrl = ""
    }
































    });
        context.Lessons.AddRange(lessons);
        await context.SaveChangesAsync();
    }
}