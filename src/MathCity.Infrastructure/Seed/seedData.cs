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

            await SubjectSeeder.SeedAsync(context);
            await ChapterSeeder.SeedAsync(context);
            await TopicSeed.SeedAsync(context);


            // Lessons

            await AlgebraLessonSeed.SeedAsync(context);
            await CalculusLessonSeeder.SeedAsync(context);
            await ComplexNumbersLessonSeeder.SeedAsync(context);
            await CoordinateGeometryLessonSeeder.SeedAsync(context);
            await DifferentialEquationsLessonSeeder.SeedAsync(context);
            await DiscreteMathematicsLessonSeeder.SeedAsync(context);
            await FunctionsLessonSeeder.SeedAsync(context);
            await GeometryLessonSeeder.SeedAsync(context);
            await LogicAndSetTheoryLessonSeeder.SeedAsync(context);
            await MatricesAndDeterminantsLessonSeeder.SeedAsync(context);
            await ProbabilityLessonSeeder.SeedAsync(context);
            await SequencesAndSeriesLessonSeeder.SeedAsync(context);
            await StatisticsLessonSeeder.SeedAsync(context);
            await TrigonometryLessonSeeder.SeedAsync(context);
            await VectorsLessonSeeder.SeedAsync(context);


            // Metadata

            await TagSeed.SeedAsync(context);


            // Relations

            await LessonTagSeeder.SeedAsync(context);


            // Questions

            await PracticeQuestionSeeder.SeedAsync(context);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;

        } 
    }
}