using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathCity.Infrastructure.Persistence.Configurations;
public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>

    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapters");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(1000);

            builder.Property(x => x.DisplayOrder)
                   .IsRequired();

        builder.HasIndex(x => new
        {
            x.SubjectId,
            x.DisplayOrder
        }).IsUnique();

        builder.HasOne(x => x.Subject)
                   .WithMany(x => x.Chapters)
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    
}
