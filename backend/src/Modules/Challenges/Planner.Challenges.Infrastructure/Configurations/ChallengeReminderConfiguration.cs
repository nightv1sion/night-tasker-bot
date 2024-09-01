using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Challenges.Domain.Challenges.Entities;

namespace Planner.Challenges.Infrastructure.Configurations;

public sealed class ChallengeReminderConfiguration : IEntityTypeConfiguration<ChallengeReminder>
{
    public void Configure(EntityTypeBuilder<ChallengeReminder> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.RemindAt)
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .IsRequired();

        builder
            .Property(x => x.ChallengeId)
            .ValueGeneratedNever()
            .IsRequired();
    }
    
    public const string TableName = "challenge_reminders";
}
