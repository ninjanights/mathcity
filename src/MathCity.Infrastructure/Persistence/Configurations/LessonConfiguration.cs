using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathCity.Infrastructure.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.Slug)
               .HasMaxLength(200)
               .IsRequired();

        builder.HasIndex(x => x.Slug)
               .IsUnique();

        builder.Property(x => x.Summary)
               .HasMaxLength(1000);

        builder.Property(x => x.Content)
               .IsRequired();

        builder.Property(x => x.ReadingTimeMinutes)
               .IsRequired();

        builder.Property(x => x.IsPublished)
               .IsRequired();

        builder.HasOne(x => x.Topic)
               .WithMany(x => x.Lessons)
               .HasForeignKey(x => x.TopicId)
               .OnDelete(DeleteBehavior.Cascade);
    }




}