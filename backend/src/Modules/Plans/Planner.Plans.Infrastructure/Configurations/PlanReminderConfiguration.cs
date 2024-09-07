using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Plans.Domain.Plans.Entities;

namespace Planner.Plans.Infrastructure.Configurations;

public sealed class PlanReminderConfiguration : IEntityTypeConfiguration<PlanReminder>
{
    public void Configure(EntityTypeBuilder<PlanReminder> builder)
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
            .Property(x => x.PlanId)
            .ValueGeneratedNever()
            .IsRequired();
    }
    
    public const string TableName = "plan_reminders";
}
