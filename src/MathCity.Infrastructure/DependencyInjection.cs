using MathCity.Application.Features.Authentication.Interfaces;
using MathCity.Infrastructure.Authentication;
using MathCity.Infrastructure.Identity;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Application.Features.Users.Interfaces;
using MathCity.Infrastructure.Services;


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


    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;

        options.Password.RequiredLength = 6;
    })
     .AddRoles<ApplicationRole>()
     .AddEntityFrameworkStores<ApplicationDbContext>();

     services.Configure<JwtSettings>(
        configuration.GetSection("Jwt"));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;



    }
}
