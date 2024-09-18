using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Infrastructure.Configurations;

internal sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(entity => entity.Id);

        builder
            .Property(entity => entity.Message)
            .IsRequired();

        builder
            .Property(entity => entity.DestinationUserId)
            .IsRequired();

        builder
            .Property(entity => entity.ScheduledAt)
            .IsRequired();
        
        builder
            .Property(entity => entity.SentAt)
            .IsRequired(false);

        builder
            .Property(entity => entity.ExternalId)
            .IsRequired();

        builder
            .HasIndex(entity => entity.ExternalId)
            .IsUnique();
    }

    public const string TableName = "notifications";
}
