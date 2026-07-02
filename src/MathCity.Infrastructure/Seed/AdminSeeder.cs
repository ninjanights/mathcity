using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Infrastructure.Identity;
using MathCity.Shared.Constants;
using Microsoft.AspNetCore.Identity;

namespace MathCity.Infrastructure.Seed;

public static class AdminSeeder
{
    public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager)
    {
        const string adminEmail = "mathcity@gmail.com";
        const string adminPassword = "blurrymoon";

        var admin = await userManager.FindByEmailAsync(adminEmail);

        if (admin != null)
            return;

        admin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "MathCity Admin",
            EmailConfirmed = true,
            IsActive = true
        };

        var result = await userManager.CreateAsync(admin, adminPassword);

        if (!result.Succeeded)
        {
            // Seeding failed; errors intentionally not written to console in production.
            return;
        }

        await userManager.AddToRoleAsync(
            admin,
            Roles.Admin);
    }
}
