using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;

public static class TagSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Tags.Any())
            return;
        var tags = new List<Tag>
{
    new Tag { Name = "Introduction",     Slug = "introduction" },
    new Tag { Name = "Concept",          Slug = "concept" },
    new Tag { Name = "Definition",       Slug = "definition" },
    new Tag { Name = "Theory",           Slug = "theory" },
    new Tag { Name = "Formula",          Slug = "formula" },
    new Tag { Name = "Derivation",       Slug = "derivation" },
    new Tag { Name = "Proof",            Slug = "proof" },
    new Tag { Name = "Example",          Slug = "example" },
    new Tag { Name = "Visualization",    Slug = "visualization" },
    new Tag { Name = "Application",      Slug = "application" },

    new Tag { Name = "Practice",         Slug = "practice" },
    new Tag { Name = "Exercise",         Slug = "exercise" },
    new Tag { Name = "Quiz",             Slug = "quiz" },
    new Tag { Name = "Challenge",        Slug = "challenge" },
    new Tag { Name = "Revision",         Slug = "revision" },

    new Tag { Name = "Summary",          Slug = "summary" },
    new Tag { Name = "Reference",        Slug = "reference" },
    new Tag { Name = "Interactive",      Slug = "interactive" },
    new Tag { Name = "Visual Guide",     Slug = "visual-guide" },
    new Tag { Name = "Step-by-Step",     Slug = "step-by-step" },
    new Tag { Name = "Worked Example",   Slug = "worked-example" },
    new Tag { Name = "Common Mistakes",  Slug = "common-mistakes" },
    new Tag { Name = "Tips & Tricks",    Slug = "tips-and-tricks" },

    new Tag { Name = "Real World",       Slug = "real-world" },
    new Tag { Name = "Historical Note",  Slug = "historical-note" },
    new Tag { Name = "Fun Fact",         Slug = "fun-fact" },
};

        context.Tags.AddRange(tags);
        await context.SaveChangesAsync();
    }
}