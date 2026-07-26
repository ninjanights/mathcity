using MathCity.Infrastructure.Identity;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Seed;

public static class SeedData
{
    public static async Task InitializeAsync(ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                        RoleManager<ApplicationRole> roleManager)
    {
        // Identity
        await RoleSeeder.SeedAsync(roleManager);
        await AdminSeeder.SeedAsync(userManager);

        // Learning Content
        await SubjectSeeder.SeedAsync(context);
        await ChapterSeeder.SeedAsync(context);
        await TopicSeed.SeedAsync(context);
        await AlgebraLessonSeed.SeedAsync(context);

        await TagSeed.SeedAsync(context);



        // Depends on Lesson + Tag
        await LessonTagSeeder.SeedAsync(context);

        // Depends on Lesson
        //await PracticeQuestionSeeder.SeedAsync(context);
    }
}