using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Plans.Domain.Plans.Entities;

namespace Planner.Plans.Infrastructure.Configurations;

internal sealed class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
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
            .HasForeignKey(entity => entity.PlanId);

        builder
            .Navigation(entity => entity.Reminders)
            .AutoInclude();
    }

    public const string TableName = "plans";
}
