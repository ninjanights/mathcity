using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathCity.Infrastructure.Persistence.Configurations;

internal class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Role)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Context)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Message)
            .HasMaxLength(8000)
            .IsRequired();

        builder.HasOne(x => x.ChatSession)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatSessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.ChatSessionId);

        builder.HasIndex(x => x.SubjectId);
        builder.HasIndex(x => x.ChapterId);
        builder.HasIndex(x => x.TopicId);
        builder.HasIndex(x => x.LessonId);
    }
}