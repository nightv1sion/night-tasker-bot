using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Infrastructure.Configurations;

internal sealed class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Name)
            .IsRequired();

        builder.Property(entity => entity.Description)
            .IsRequired(false);

        builder.Property(entity => entity.UserId)
            .IsRequired();

        builder.HasIndex(entity => entity.UserId);

        builder
            .HasMany(entity => entity.Reminders)
            .WithOne()
            .HasForeignKey(entity => entity.ChallengeId);
    }

    public const string TableName = "challenges";
}
