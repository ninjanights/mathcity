using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MathCity.Infrastructure.Identity;
using MathCity.Shared.Constants;
using Microsoft.AspNetCore.Identity;

namespace MathCity.Infrastructure.Seed;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            var result = await roleManager.CreateAsync(
      new ApplicationRole
      {
          Name = Roles.Admin
      });

            if (!result.Succeeded)
            {
                // Seeding failed; errors intentionally not written to console in production.
            }
        }

        if (!await roleManager.RoleExistsAsync(Roles.Student))
        {
            await roleManager.CreateAsync(
                new ApplicationRole
                {
                    Name = Roles.Student
                });
        }
    }
}
