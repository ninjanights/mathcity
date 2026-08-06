using MathCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathCity.Infrastructure.Persistence.Configurations;

internal class ChatSessionConfiguration : IEntityTypeConfiguration<ChatSession>
{
    public void Configure(EntityTypeBuilder<ChatSession> builder)
    {
        builder.ToTable("ChatSessions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SessionId)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.SessionId)
            .IsUnique();

        builder.Property(x => x.LastAccessedAt)
            .IsRequired();

        builder.Property(x => x.ExpiresAt)
            .IsRequired();

        builder.HasMany(x => x.Messages)
            .WithOne(x => x.ChatSession)
            .HasForeignKey(x => x.ChatSessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}