using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Persistence.Configurations;

public class LessonVectorEmbeddingConfiguration
    : IEntityTypeConfiguration<LessonVectorEmbedding>
{
    public void Configure(EntityTypeBuilder<LessonVectorEmbedding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content)
            .IsRequired();

        builder.Property(x => x.TokenCount)
            .IsRequired();

        builder.Property(x => x.ChunkIndex)
            .IsRequired();

        builder.Property(x => x.ChunkType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Embedding)
    .HasColumnType("vector(1536)")
    .IsRequired();



        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.VectorEmbeddings)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Performance Indexes


        builder.HasIndex(x => x.LessonId);

        builder.HasIndex(x => x.ChunkType);

        builder.HasIndex(x => new
        {
            x.LessonId,
            x.ChunkType,
            x.ChunkIndex
        });

        builder.ToTable("LessonVectorEmbeddings");
    }
}