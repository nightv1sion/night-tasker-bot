using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Application.ApplicationServices;

public interface INotificator
{
    Task SendNotification(Notification notification, CancellationToken cancellationToken);
}
