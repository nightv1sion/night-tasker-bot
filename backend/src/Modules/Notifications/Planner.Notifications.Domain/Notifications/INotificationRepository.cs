namespace Planner.Notifications.Domain.Notifications;

public interface INotificationRepository
{
    Task InsertAsync(Notification notification, CancellationToken cancellationToken);
}
