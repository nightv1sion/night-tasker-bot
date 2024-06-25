using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Core.Domain.ChallengeMessages.Entities;

namespace TaskTracker.Infrastructure.Persistence.Configurations;

internal sealed class ChallengeMessageConfiguration : IEntityTypeConfiguration<ChallengeMessage>
{
    public void Configure(EntityTypeBuilder<ChallengeMessage> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MessageId)
            .IsRequired();

        builder.Property(x => x.ChallengeId)
            .IsRequired();

        builder.Property(x => x.SentAt)
            .IsRequired();

        builder.HasIndex(x => x.MessageId).IsUnique();

        builder.HasOne(x => x.Challenge)
            .WithMany()
            .HasForeignKey(x => x.ChallengeId);
    }

    public const string TableName = "challenge_messages";
}