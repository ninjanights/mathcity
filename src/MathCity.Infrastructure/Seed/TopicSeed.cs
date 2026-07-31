using Microsoft.EntityFrameworkCore;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;

public static class TopicSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {

        if (await context.Topics.AnyAsync())
            return;
        var chapters = await context.Chapters.ToDictionaryAsync(c => c.Title);

        var topics = new List<Topic>();

        var duplicates = topics
    .GroupBy(t => new { t.ChapterId, t.DisplayOrder })
    .Where(g => g.Count() > 1)
    .ToList();

        Console.WriteLine($"---------Duplicate groups: {duplicates.Count}---------");

        foreach (var g in duplicates)
        {
            var chapter = chapters.Values.First(c => c.Id == g.Key.ChapterId);

            Console.WriteLine($"Chapter: {chapter.Title}");
            Console.WriteLine($"DisplayOrder: {g.Key.DisplayOrder}");

            foreach (var t in g)
            {
                Console.WriteLine($"  {t.Title}");
            }
        }

        topics.AddRange(new[]
{
            // Algebra
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Algebraic Expressions", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Linear Equations", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Simultaneous Equations", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Inequalities", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Quadratic Equations", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Polynomials", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Factorization", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Rational Expressions", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Exponents", DisplayOrder = 9 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Radicals (Surds)", DisplayOrder = 10 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Logarithms", DisplayOrder = 11 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Absolute Value", DisplayOrder = 12 },
            new Topic { ChapterId = chapters["Algebra"].Id, Title = "Algebraic Identities", DisplayOrder = 13 },

            // Geometry

            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Points, Lines & Angles", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Triangles", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Congruence", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Similarity", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Quadrilaterals", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Polygons", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Circles", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Constructions", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Area", DisplayOrder = 9 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Perimeter", DisplayOrder = 10 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Transformations", DisplayOrder = 11 },
            new Topic { ChapterId = chapters["Geometry"].Id, Title = "Coordinate Proofs", DisplayOrder = 12 },

            // Coordinate Geometry 3

            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Cartesian Plane", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Distance Formula", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Midpoint Formula", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Section Formula", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Straight Line", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Pair of Straight Lines", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Circle", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Parabola", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Ellipse", DisplayOrder = 9 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Hyperbola", DisplayOrder = 10 },
            new Topic { ChapterId = chapters["Coordinate Geometry"].Id, Title = "Conic Sections", DisplayOrder = 11 },

            // Trigonometry 4

            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Trigonometric Ratios", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Trigonometric Identities", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Compound Angles", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Double & Half Angles", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Inverse Trigonometric Functions", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Trigonometric Equations", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Heights & Distances", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Trigonometry"].Id, Title = "Graphs of Trigonometric Functions", DisplayOrder = 8 },










            // Functions 5

            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Relations", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Types of Functions", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Domain & Range", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Composite Functions", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Inverse Functions", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Graphing Functions", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Piecewise Functions", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Functions in Set Theory"].Id, Title = "Transformations of Functions", DisplayOrder = 8 },

            // Sequences & Series 6

            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Arithmetic Progression (AP)", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Geometric Progression (GP)", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Harmonic Progression (HP)", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Sigma Notation", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Finite Series", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Infinite Series", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Binomial Expansion", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Sequences & Series"].Id, Title = "Mathematical Induction", DisplayOrder = 8 },











            // Matrices & Determinants 7

            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Matrix Basics", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Types of Matrices", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Matrix Operations", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Determinants", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Inverse Matrix", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Rank of Matrix", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "System of Linear Equations", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Eigenvalues", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Matrices & Determinants"].Id, Title = "Eigenvectors", DisplayOrder = 9 },


            // Vectors 8

            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Vector Basics", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Vector Operations", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Dot Product", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Cross Product", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Projection", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Direction Cosines", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Lines in Space", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Vectors"].Id, Title = "Planes", DisplayOrder = 8 },


            // Probability 9

            new Topic { ChapterId = chapters["Probability"].Id, Title = "Basic Probability", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Conditional Probability", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Bayes' Theorem", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Random Variables", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Probability Distributions", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Expected Value", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Binomial Distribution", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Probability"].Id, Title = "Normal Distribution", DisplayOrder = 8 },

            // Statistics 10

            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Data Collection", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Measures of Central Tendency", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Measures of Dispersion", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Frequency Distribution", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Histograms", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Box Plots", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Correlation", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Regression", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Sampling", DisplayOrder = 9 },
            new Topic { ChapterId = chapters["Statistics"].Id, Title = "Hypothesis Testing", DisplayOrder = 10 },


            // Calculus 11

            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Limits", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Continuity", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Differentiation", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Applications of Derivatives", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Indefinite Integration", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Definite Integration", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Applications of Integration", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Parametric Equations", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Polar Coordinates", DisplayOrder = 9 },
            new Topic { ChapterId = chapters["Calculus"].Id, Title = "Multivariable Calculus", DisplayOrder = 10 },


            // Differential Equations 12

            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Introduction", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "First Order Differential Equations", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Separable Equations", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Linear Differential Equations", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Homogeneous Equations", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Exact Equations", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Higher Order Differential Equations", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Differential Equations"].Id, Title = "Applications", DisplayOrder = 8 },


            // Complex Numbers 13

            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "Imaginary Numbers", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "Complex Plane", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "Polar Form", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "Modulus & Argument", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "De Moivre's Theorem", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "Roots of Complex Numbers", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Complex Numbers"].Id, Title = "Complex Functions", DisplayOrder = 7 },


            // Discrete Mathematics 14

            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Counting Principles", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Permutations", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Combinations", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Recurrence Relations", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Graph Theory", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Trees", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Boolean Algebra", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Number Theory", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Discrete Mathematics"].Id, Title = "Algorithms", DisplayOrder = 9 },

            // Mathematical Logic & Set Theory 15

            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Sets", DisplayOrder = 1 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Set Operations", DisplayOrder = 2 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Venn Diagrams", DisplayOrder = 3 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Cartesian Product", DisplayOrder = 4 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Relations in Set Theory", DisplayOrder = 5 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Functions in Set Theory", DisplayOrder = 6 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Propositional Logic", DisplayOrder = 7 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Predicate Logic", DisplayOrder = 8 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Truth Tables", DisplayOrder = 9 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Logical Equivalence", DisplayOrder = 10 },
            new Topic { ChapterId = chapters["Logic & Set Theory"].Id, Title = "Mathematical Proof Techniques", DisplayOrder = 11 },
        });

        context.Topics.AddRange(topics);
        await context.SaveChangesAsync();


    }





}

