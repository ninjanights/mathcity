using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Entities;

using MathCity.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Persistence.Context;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser , ApplicationRole, Guid>
{ 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Subject> Subjects => Set<Subject>();

    public DbSet<Topic> Topics => Set<Topic>();

    public DbSet<Chapter> Chapters => Set<Chapter>();

    public DbSet<Lesson> Lessons => Set<Lesson>();

    public DbSet<LessonResource> LessonResources => Set<LessonResource>();

    public DbSet<PracticeQuestion> PracticeQuestions => Set<PracticeQuestion>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Bookmark> Bookmarks => Set<Bookmark>();

    public DbSet<Progress> Progress => Set<Progress>();

    public DbSet<Tag> Tags => Set<Tag>();

    public DbSet<LessonTag> LessonTags => Set<LessonTag>();
}
