using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathCity.Infrastructure.Persistence.Configurations;

public class LessonTagConfiguration : IEntityTypeConfiguration<LessonTag>
{
    public void Configure(EntityTypeBuilder<LessonTag> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.LessonTags)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Tag)
            .WithMany(x => x.LessonTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        // Prevent duplicate Lesson-Tag pairs
        builder.HasIndex(x => new
        {
            x.LessonId,
            x.TagId
        }).IsUnique();
    }
}