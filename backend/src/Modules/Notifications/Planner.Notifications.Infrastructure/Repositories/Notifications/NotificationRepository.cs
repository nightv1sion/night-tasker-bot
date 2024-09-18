using Microsoft.EntityFrameworkCore;
using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Infrastructure.Repositories.Notifications;

internal sealed class NotificationRepository(
    NotificationsDbContext dbContext)
    : GenericRepository<Notification>(dbContext), INotificationRepository
{
    public Task<Notification?> TryGetBy(Guid externalId, CancellationToken cancellationToken)
    {
        return DbContext.Set<Notification>()
            .Where(x => x.ExternalId == externalId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<Notification>> GetNotSentBy(
        DateTimeOffset maxScheduledAt,
        CancellationToken cancellationToken)
    {
        return await DbContext.Set<Notification>()
            .Where(x => x.SentAt == null)
            .Where(x => x.ScheduledAt <= maxScheduledAt)
            .ToArrayAsync(cancellationToken: cancellationToken);
    }

    public void Remove(Notification notification)
    {
        DbContext.Set<Notification>().Remove(notification);
    }
}
