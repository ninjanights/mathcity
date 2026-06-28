using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using MathCity.Infrastructure.Identity;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;


namespace MathCity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));



        });
        services
     .AddIdentityCore<ApplicationUser>()
     .AddRoles<ApplicationRole>()
     .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;



    }
}
