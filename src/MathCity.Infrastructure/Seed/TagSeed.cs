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
            // Learning Style
            new Tag { Name = "Introduction" },
            new Tag { Name = "Concept" },
            new Tag { Name = "Definition" },
            new Tag { Name = "Theory" },
            new Tag { Name = "Formula" },
            new Tag { Name = "Derivation" },
            new Tag { Name = "Proof" },
            new Tag { Name = "Example" },
            new Tag { Name = "Visualization" },
            new Tag { Name = "Application" },

            
            // Practice
            
            new Tag { Name = "Practice" },
            new Tag { Name = "Exercise" },
            new Tag { Name = "Quiz" },
            new Tag { Name = "Challenge" },
            new Tag { Name = "Revision" },

            
            // Learning Support
            
            new Tag { Name = "Summary" },
            new Tag { Name = "Reference" },
            new Tag { Name = "Interactive" },
            new Tag { Name = "Visual Guide" },
            new Tag { Name = "Step-by-Step" },
            new Tag { Name = "Worked Example" },
            new Tag { Name = "Common Mistakes" },
            new Tag { Name = "Tips & Tricks" },

            
            // Context
           
            new Tag { Name = "Real World" },
            new Tag { Name = "Historical Note" },
            new Tag { Name = "Fun Fact" }
        };

        context.Tags.AddRange(tags);
        await context.SaveChangesAsync();
    }
}