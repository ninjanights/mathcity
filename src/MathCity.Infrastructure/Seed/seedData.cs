using MathCity.Infrastructure.Identity;
using MathCity.Infrastructure.Persistence.Context;
using MathCity.Infrastructure.Seed.Lessons;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Seed;

public static class SeedData
{
    public static async Task InitializeAsync(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            // Identity

            await RoleSeeder.SeedAsync(roleManager);
            await AdminSeeder.SeedAsync(userManager);


            // Learning Structure
            Console.WriteLine("Seeding Subjects...");
            await SubjectSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Chapter...");
            await ChapterSeeder.SeedAsync(context);

            Console.WriteLine("Seeding topic...");
            await TopicSeed.SeedAsync(context);


            // Lessons
            Console.WriteLine("Seeding alge...");
            await AlgebraLessonSeed.SeedAsync(context);

            Console.WriteLine("Seeding calc...");
            await CalculusLessonSeeder.SeedAsync(context);
            
            Console.WriteLine("Seeding complex...");
            await ComplexNumbersLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding coor...");
            await CoordinateGeometryLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding diff equa...");
            await DifferentialEquationsLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding discre...");
            await DiscreteMathematicsLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding function...");
            await FunctionsLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Geo...");
            await GeometryLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Logic...");
            await LogicAndSetTheoryLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Matric...");
            await MatricesAndDeterminantsLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Probab...");
            await ProbabilityLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding seq...");
            await SequencesAndSeriesLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Stat...");
            await StatisticsLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Triginam...");
            await TrigonometryLessonSeeder.SeedAsync(context);

            Console.WriteLine("Seeding Vector L...");
            await VectorsLessonSeeder.SeedAsync(context);


            // Metadata
            Console.WriteLine("Seeding Tag...");
            await TagSeed.SeedAsync(context);


            // Relations
            Console.WriteLine("Seeding Lesson Tag...");
            await LessonTagSeeder.SeedAsync(context);


            // Questions
            Console.WriteLine("Seeding P Q...");
            await PracticeQuestionSeeder.SeedAsync(context);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;

        } 
    }
}