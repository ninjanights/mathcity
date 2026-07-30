
// Logic & Set Theory Lesson Seeder


using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class LogicAndSetTheoryLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            
// Sets


new Lesson
{
    TopicId = topics["Sets"].Id,
    Title = "Introduction to Sets",
    Slug = "introduction-to-sets",
    Summary = "Learn the fundamentals of sets, understand elements, notation, types of sets, and how collections of objects are represented mathematically.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Sets"].Id,
    Title = "Set Operations and Relationships",
    Slug = "set-operations-and-relationships",
    Summary = "Explore set operations including union, intersection, difference, complement, subsets, power sets, and methods for solving problems involving multiple sets.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Sets"].Id,
    Title = "Applications and Practice of Sets",
    Slug = "applications-and-practice-of-sets",
    Summary = "Apply set theory concepts to solve advanced problems and explore applications in databases, probability, computer science, logic, artificial intelligence, and mathematical modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

// Set Operations


new Lesson
{
    TopicId = topics["Set Operations"].Id,
    Title = "Introduction to Set Operations",
    Slug = "introduction-to-set-operations",
    Summary = "Learn the fundamentals of set operations, understand how sets can be combined and compared, and explore the basic rules governing operations on collections.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Set Operations"].Id,
    Title = "Advanced Set Operations and Laws",
    Slug = "advanced-set-operations-and-laws",
    Summary = "Explore union, intersection, difference, complement, Cartesian products, De Morgan's laws, and advanced techniques for solving complex set-based problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Set Operations"].Id,
    Title = "Applications and Practice of Set Operations",
    Slug = "applications-and-practice-of-set-operations",
    Summary = "Apply set operation concepts to solve advanced problems and explore applications in databases, probability, computer science, artificial intelligence, and mathematical reasoning.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Venn Diagrams


new Lesson
{
    TopicId = topics["Venn Diagrams"].Id,
    Title = "Introduction to Venn Diagrams",
    Slug = "introduction-to-venn-diagrams",
    Summary = "Learn the fundamentals of Venn diagrams, understand how sets are represented visually, and explore how relationships between groups can be analyzed using diagrams.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Venn Diagrams"].Id,
    Title = "Solving Problems Using Venn Diagrams",
    Slug = "solving-problems-using-venn-diagrams",
    Summary = "Explore how to represent unions, intersections, complements, and differences using Venn diagrams and solve complex set relationship problems.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Venn Diagrams"].Id,
    Title = "Applications and Practice of Venn Diagrams",
    Slug = "applications-and-practice-of-venn-diagrams",
    Summary = "Apply Venn diagram techniques to solve advanced problems and explore applications in probability, statistics, databases, logic, surveys, artificial intelligence, and data analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Cartesian Product


new Lesson
{
    TopicId = topics["Cartesian Product"].Id,
    Title = "Introduction to Cartesian Product",
    Slug = "introduction-to-cartesian-product",
    Summary = "Learn the fundamentals of Cartesian products, understand ordered pairs, and explore how sets can be combined to create new mathematical structures.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Cartesian Product"].Id,
    Title = "Properties and Applications of Cartesian Products",
    Slug = "properties-and-applications-of-cartesian-products",
    Summary = "Explore Cartesian product properties, ordered pairs, relations, functions, and how products of sets form the foundation of coordinate systems and relational structures.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Cartesian Product"].Id,
    Title = "Advanced Problems and Practice of Cartesian Products",
    Slug = "advanced-problems-and-practice-of-cartesian-products",
    Summary = "Apply Cartesian product concepts to solve advanced problems and explore applications in databases, programming, graph theory, discrete structures, and computer science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Relations


new Lesson
{
    TopicId = topics["Relations in Set Theory"].Id,
    Title = "Introduction to Relations in Set Theory",
    Slug = "introduction-to-set-relations",
    Summary = "Learn the fundamentals of relations, understand ordered pairs, domain and range, and explore how relationships between mathematical objects are represented.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Relations in Set Theory"].Id,
    Title = "Properties and Types of Relations",
    Slug = "properties-and-types-of-relations",
    Summary = "Explore different types of relations including reflexive, symmetric, antisymmetric, and transitive relations, along with methods for analyzing relation properties.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Relations in Set Theory"].Id,
    Title = "Applications and Practice of Relations in Set Theory",
    Slug = "relations-in-set-theory-introduction",
    Summary = "Apply relation concepts to solve advanced problems and explore applications in databases, graph theory, programming, algorithms, artificial intelligence, and mathematical modelling.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Functions


new Lesson
{
    TopicId = topics["Functions in Set Theory"].Id,
    Title = "Introduction to Functions",
    Slug = "introduction-to-functions",
    Summary = "Learn the fundamentals of functions, understand mappings between sets, domain and range, and explore how functions describe relationships between mathematical objects.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Functions in Set Theory"].Id,
    Title = "Types and Properties of Functions",
    Slug = "types-and-properties-of-functions",
    Summary = "Explore different types of functions including one-to-one, onto, bijective functions, inverse functions, and methods for analyzing function properties.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Functions in Set Theory"].Id,
    Title = "Applications and Practice of Functions",
    Slug = "applications-and-practice-of-functions",
    Summary = "Apply function concepts to solve advanced problems and explore applications in computer science, programming, databases, artificial intelligence, modelling, and mathematical systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Propositional Logic


new Lesson
{
    TopicId = topics["Propositional Logic"].Id,
    Title = "Introduction to Propositional Logic",
    Slug = "introduction-to-propositional-logic",
    Summary = "Learn the fundamentals of propositional logic, understand statements, truth values, logical operators, and how mathematical reasoning is represented using logic.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Propositional Logic"].Id,
    Title = "Logical Operators and Truth Tables",
    Slug = "logical-operators-and-truth-tables",
    Summary = "Explore logical operators including AND, OR, NOT, implication, and equivalence. Learn how to construct truth tables and analyze compound propositions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Propositional Logic"].Id,
    Title = "Applications and Practice of Propositional Logic",
    Slug = "applications-and-practice-of-propositional-logic",
    Summary = "Apply propositional logic concepts to solve advanced reasoning problems and explore applications in computer programming, digital circuits, artificial intelligence, databases, and formal verification.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Predicate Logic


new Lesson
{
    TopicId = topics["Predicate Logic"].Id,
    Title = "Introduction to Predicate Logic",
    Slug = "introduction-to-predicate-logic",
    Summary = "Learn the fundamentals of predicate logic, understand predicates, variables, quantifiers, and how mathematical statements can express relationships between objects.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Predicate Logic"].Id,
    Title = "Quantifiers and Logical Reasoning",
    Slug = "quantifiers-and-logical-reasoning",
    Summary = "Explore universal and existential quantifiers, logical expressions, negations, and techniques for analyzing complex mathematical statements using predicate logic.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Predicate Logic"].Id,
    Title = "Applications and Practice of Predicate Logic",
    Slug = "applications-and-practice-of-predicate-logic",
    Summary = "Apply predicate logic concepts to solve advanced reasoning problems and explore applications in computer science, artificial intelligence, databases, programming languages, and automated reasoning systems.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Truth Tables


new Lesson
{
    TopicId = topics["Truth Tables"].Id,
    Title = "Introduction to Truth Tables",
    Slug = "introduction-to-truth-tables",
    Summary = "Learn the fundamentals of truth tables, understand how logical expressions are evaluated, and explore how truth values represent the outcomes of logical statements.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Truth Tables"].Id,
    Title = "Constructing and Simplifying Truth Tables",
    Slug = "constructing-and-simplifying-truth-tables",
    Summary = "Explore methods for building truth tables, evaluating compound propositions, simplifying logical expressions, and analyzing relationships between logical statements.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Truth Tables"].Id,
    Title = "Applications and Practice of Truth Tables",
    Slug = "applications-and-practice-of-truth-tables",
    Summary = "Apply truth table concepts to solve advanced logic problems and explore applications in digital circuits, computer science, programming, artificial intelligence, and formal verification.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Logical Equivalence


new Lesson
{
    TopicId = topics["Logical Equivalence"].Id,
    Title = "Introduction to Logical Equivalence",
    Slug = "introduction-to-logical-equivalence",
    Summary = "Learn the fundamentals of logical equivalence, understand when two logical statements have the same truth value, and explore the principles behind equivalent expressions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Logical Equivalence"].Id,
    Title = "Laws and Methods of Logical Equivalence",
    Slug = "laws-and-methods-of-logical-equivalence",
    Summary = "Explore logical equivalence laws including identity, domination, idempotent, double negation, De Morgan's laws, and techniques for simplifying complex logical expressions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Logical Equivalence"].Id,
    Title = "Applications and Practice of Logical Equivalence",
    Slug = "applications-and-practice-of-logical-equivalence",
    Summary = "Apply logical equivalence concepts to solve advanced reasoning problems and explore applications in programming, digital circuits, automated theorem proving, artificial intelligence, and computer science.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},
// Mathematical Proof Techniques


new Lesson
{
    TopicId = topics["Mathematical Proof Techniques"].Id,
    Title = "Introduction to Mathematical Proofs",
    Slug = "introduction-to-mathematical-proofs",
    Summary = "Learn the fundamentals of mathematical proofs, understand the purpose of proving statements, and explore the structure of logical arguments used in mathematics.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    
},

new Lesson
{
    TopicId = topics["Mathematical Proof Techniques"].Id,
    Title = "Common Proof Methods and Strategies",
    Slug = "common-proof-methods-and-strategies",
    Summary = "Explore important proof techniques including direct proof, proof by contradiction, proof by contrapositive, mathematical induction, and counterexamples.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    
},

new Lesson
{
    TopicId = topics["Mathematical Proof Techniques"].Id,
    Title = "Advanced Proof Applications and Practice",
    Slug = "advanced-proof-applications-and-practice",
    Summary = "Apply advanced proof techniques to solve complex mathematical problems and explore their use in discrete mathematics, algorithms, computer science, and theoretical mathematics.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    
},

        };

        foreach (var lesson in lessons)
        {
            Console.WriteLine(
        $"TopicId={lesson.TopicId}, DisplayOrder={lesson.DisplayOrder}, Slug={lesson.Slug}, Title={lesson.Title}");

            var tracked = context.ChangeTracker.Entries<Lesson>();

            Console.WriteLine("Tracked lessons:");

            foreach (var e in tracked)
            {
                Console.WriteLine(
                    $"{e.Entity.TopicId} | {e.Entity.DisplayOrder} | {e.Entity.Title}");
            }


            var existing = await context.Lessons
    .AsNoTracking()
    .Where(x =>
        x.TopicId == lesson.TopicId &&
        x.DisplayOrder == lesson.DisplayOrder)
    .Select(x => new
    {
        x.Title,
        x.Slug,
        x.TopicId,
        x.DisplayOrder
    })
    .FirstOrDefaultAsync();

            if (existing != null)
            {
                Console.WriteLine("ALREADY EXISTS: --------------------------------------------------------------");
                Console.WriteLine(existing.Title);
                Console.WriteLine(existing.Slug);
            }

            context.Lessons.Add(lesson);
            await context.SaveChangesAsync();
        }
    }
}