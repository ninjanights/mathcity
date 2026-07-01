using MathCity.Application.Features.Authentication.Interfaces;
using MathCity.Application.Features.Bookmarks.Interfaces;
using MathCity.Application.Features.Chapters.Interfaces;
using MathCity.Application.Features.LessonResources.Interfaces;
using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Application.Features.LessonTags.Interfaces;
using MathCity.Application.Features.PracticeQuestions.Interfaces;
using MathCity.Application.Features.Progress.Interfaces;
using MathCity.Application.Features.Subjects.Interfaces;
using MathCity.Application.Features.Tags.Interfaces;
using MathCity.Application.Features.Topics.Interfaces;
using MathCity.Application.Features.Users.Interfaces;
using MathCity.Infrastructure.Authentication;
using MathCity.Infrastructure.Identity;
using MathCity.Infrastructure.Persistence.Context;
using MathCity.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

        services.Configure<JwtSettings>(
        configuration.GetSection("Jwt"));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IChapterService, ChapterService>();
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<ILessonResourceService, LessonResourceService>();
        services.AddScoped<IPracticeQuestionService, PracticeQuestionService>();
        services.AddScoped<IProgressService, ProgressService>();
        services.AddScoped<IBookmarkService, BookmarkService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ILessonTagService, LessonTagService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();


        return services;



    }
}
