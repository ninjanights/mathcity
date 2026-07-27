// ==========================================================
// Discrete Mathematics Lesson Seeder
// ==========================================================

using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class DiscreteMathematicsLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {

            // ==========================================================
// Counting Principles
// ==========================================================

new Lesson
{
    TopicId = topics["Counting Principles"].Id,
    Title = "Introduction to Counting Principles",
    Slug = "introduction-to-counting-principles",
    Summary = "Learn the fundamentals of counting principles, understand systematic ways to count possibilities, and explore the foundation of combinatorics.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Counting Principles"].Id,
    Title = "Permutations and Combinations",
    Slug = "permutations-and-combinations",
    Summary = "Explore advanced counting techniques including permutations, combinations, factorials, arrangements, selections, and methods for solving counting problems efficiently.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Counting Principles"].Id,
    Title = "Applications and Practice of Counting Principles",
    Slug = "applications-and-practice-of-counting-principles",
    Summary = "Apply counting principles to solve advanced problems and explore applications in probability, algorithms, cryptography, computer science, data analysis, and software engineering.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Permutations
// ==========================================================

new Lesson
{
    TopicId = topics["Permutations"].Id,
    Title = "Introduction to Permutations",
    Slug = "introduction-to-permutations",
    Summary = "Learn the fundamentals of permutations, understand ordered arrangements, and explore how the order of objects affects counting outcomes.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Permutations"].Id,
    Title = "Permutation Formulas and Techniques",
    Slug = "permutation-formulas-and-techniques",
    Summary = "Explore permutation formulas, factorial notation, arrangements with repetition, circular permutations, and techniques for solving complex counting problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Permutations"].Id,
    Title = "Applications and Practice of Permutations",
    Slug = "applications-and-practice-of-permutations",
    Summary = "Apply permutation concepts to solve advanced problems and explore applications in probability, algorithms, scheduling, cryptography, computer science, and data organization.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Combinations
// ==========================================================

new Lesson
{
    TopicId = topics["Combinations"].Id,
    Title = "Introduction to Combinations",
    Slug = "introduction-to-combinations",
    Summary = "Learn the fundamentals of combinations, understand unordered selections, and explore how combinations differ from permutations in counting problems.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Combinations"].Id,
    Title = "Combination Formulas and Techniques",
    Slug = "combination-formulas-and-techniques",
    Summary = "Explore combination formulas, binomial coefficients, selections with restrictions, and techniques for solving advanced counting problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Combinations"].Id,
    Title = "Applications and Practice of Combinations",
    Slug = "applications-and-practice-of-combinations",
    Summary = "Apply combination concepts to solve advanced problems and explore applications in probability, statistics, algorithms, cryptography, computer science, and decision-making systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Recurrence Relations
// ==========================================================

new Lesson
{
    TopicId = topics["Recurrence Relations"].Id,
    Title = "Introduction to Recurrence Relations",
    Slug = "introduction-to-recurrence-relations",
    Summary = "Learn the fundamentals of recurrence relations, understand how sequences are defined using previous terms, and explore their importance in discrete mathematics and computer science.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Recurrence Relations"].Id,
    Title = "Solving Recurrence Relations",
    Slug = "solving-recurrence-relations",
    Summary = "Explore techniques for solving recurrence relations including iteration, substitution, characteristic equations, and methods used to analyze algorithm complexity.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Recurrence Relations"].Id,
    Title = "Applications and Practice of Recurrence Relations",
    Slug = "applications-and-practice-of-recurrence-relations",
    Summary = "Apply recurrence relation concepts to solve advanced problems and explore applications in algorithms, data structures, dynamic programming, cryptography, computer science, and mathematical modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Graph Theory
// ==========================================================

new Lesson
{
    TopicId = topics["Graph Theory"].Id,
    Title = "Introduction to Graph Theory",
    Slug = "introduction-to-graph-theory",
    Summary = "Learn the fundamentals of graph theory, understand vertices, edges, and graph representations, and explore how graphs model relationships and networks.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Graph Theory"].Id,
    Title = "Graph Structures and Algorithms",
    Slug = "graph-structures-and-algorithms",
    Summary = "Explore different types of graphs, paths, cycles, connectivity, graph traversal techniques, and important graph algorithms used in computer science.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Graph Theory"].Id,
    Title = "Applications and Practice of Graph Theory",
    Slug = "applications-and-practice-of-graph-theory",
    Summary = "Apply graph theory concepts to solve advanced problems and explore applications in networks, routing, social media, cybersecurity, artificial intelligence, databases, and software engineering.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Trees
// ==========================================================

new Lesson
{
    TopicId = topics["Trees"].Id,
    Title = "Introduction to Trees",
    Slug = "introduction-to-trees",
    Summary = "Learn the fundamentals of trees in discrete mathematics, understand hierarchical structures, nodes, edges, roots, and explore how trees represent connected relationships.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Trees"].Id,
    Title = "Tree Properties and Algorithms",
    Slug = "tree-properties-and-algorithms",
    Summary = "Explore different types of trees including binary trees, spanning trees, traversal methods, tree properties, and algorithms used for searching and organizing data.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Trees"].Id,
    Title = "Applications and Practice of Trees",
    Slug = "applications-and-practice-of-trees",
    Summary = "Apply tree concepts to solve advanced problems and explore applications in databases, file systems, artificial intelligence, compilers, networking, algorithms, and software engineering.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Boolean Algebra
// ==========================================================

new Lesson
{
    TopicId = topics["Boolean Algebra"].Id,
    Title = "Introduction to Boolean Algebra",
    Slug = "introduction-to-boolean-algebra",
    Summary = "Learn the fundamentals of Boolean algebra, understand binary values, logical operations, and how algebraic methods represent logical relationships.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Boolean Algebra"].Id,
    Title = "Boolean Laws and Logic Circuits",
    Slug = "boolean-laws-and-logic-circuits",
    Summary = "Explore Boolean laws, logical identities, truth tables, logic gates, simplification techniques, and their role in designing digital circuits.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Boolean Algebra"].Id,
    Title = "Applications and Practice of Boolean Algebra",
    Slug = "applications-and-practice-of-boolean-algebra",
    Summary = "Apply Boolean algebra concepts to solve advanced problems and explore applications in computer architecture, digital electronics, programming, databases, cybersecurity, and software engineering.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Number Theory
// ==========================================================

new Lesson
{
    TopicId = topics["Number Theory"].Id,
    Title = "Introduction to Number Theory",
    Slug = "introduction-to-number-theory",
    Summary = "Learn the fundamentals of number theory, understand properties of integers, prime numbers, divisibility, and explore the mathematical structures behind whole numbers.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Number Theory"].Id,
    Title = "Prime Numbers and Number Theory Techniques",
    Slug = "prime-numbers-and-number-theory-techniques",
    Summary = "Explore prime factorization, divisibility rules, greatest common divisors, modular arithmetic, congruences, and techniques used to solve number theory problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Number Theory"].Id,
    Title = "Applications and Practice of Number Theory",
    Slug = "applications-and-practice-of-number-theory",
    Summary = "Apply number theory concepts to solve advanced problems and explore applications in cryptography, cybersecurity, algorithms, computer science, coding theory, and mathematical research.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Algorithms
// ==========================================================

new Lesson
{
    TopicId = topics["Algorithms"].Id,
    Title = "Introduction to Algorithms",
    Slug = "introduction-to-algorithms",
    Summary = "Learn the fundamentals of algorithms, understand step-by-step problem solving, algorithm design principles, and how efficient solutions are created in computer science.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Algorithms"].Id,
    Title = "Algorithm Design and Analysis",
    Slug = "algorithm-design-and-analysis",
    Summary = "Explore algorithm design techniques, time complexity, space complexity, searching, sorting, recursion, divide-and-conquer, and methods for improving algorithm efficiency.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Algorithms"].Id,
    Title = "Advanced Algorithms and Applications",
    Slug = "advanced-algorithms-and-applications",
    Summary = "Apply advanced algorithm concepts including graph algorithms, dynamic programming, greedy methods, optimisation techniques, artificial intelligence, cybersecurity, and large-scale software systems.",
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