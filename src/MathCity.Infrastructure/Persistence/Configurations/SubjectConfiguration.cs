using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathCity.Infrastructure.Persistence.Configurations;

public class  SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Slug)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasIndex(x => x.Slug)
               .IsUnique();

        builder.Property(x => x.Description)
               .HasMaxLength(1000);

        builder.Property(x => x.Icon)
               .HasMaxLength(255);

        builder.Property(x => x.Color)
               .HasMaxLength(20);

        builder.Property(x => x.DisplayOrder)
               .IsRequired();

        builder.Property(x => x.IsPublished)
               .IsRequired();
    }

}
