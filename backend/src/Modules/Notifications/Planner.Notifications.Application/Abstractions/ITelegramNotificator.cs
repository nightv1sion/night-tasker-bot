namespace Planner.Notifications.Application.Abstractions;

public interface ITelegramNotificator
{
    Task SendNotification(
        long destinationUserId,
        string message,
        CancellationToken cancellationToken);
}
