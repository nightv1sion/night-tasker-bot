using Planner.Notifications.Application.Abstractions;
using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Application.ApplicationServices;

internal sealed class Notificator(ITelegramNotificator telegramNotificator) : INotificator
{
    public async Task SendNotification(Notification notification, CancellationToken cancellationToken)
    {
        await telegramNotificator.SendNotification(
            notification.DestinationUserId,
            notification.Message,
            cancellationToken);
    }
}
