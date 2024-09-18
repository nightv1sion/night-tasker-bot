namespace Planner.Notifications.Domain.Notifications;

public interface INotificationRepository
{
    Task<Notification?> TryGetBy(Guid externalId, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<Notification>> GetNotSentBy(
        DateTimeOffset maxScheduledAt,
        CancellationToken cancellationToken);
    
    Task InsertAsync(Notification notification, CancellationToken cancellationToken);

    void Remove(Notification notification);
}
