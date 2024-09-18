using Planner.Common.Application.Messaging;
using Planner.Notifications.Application.ApplicationServices;
using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Application.Notifications.SendNotifications;

internal sealed class SendNotificationsHandler(
    INotificationRepository notificationRepository,
    INotificator notificator,
    IUnitOfWork unitOfWork)
    : ICommandHandler<SendNotificationsCommand>
{
    public async Task Handle(SendNotificationsCommand request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Notification> notificationsShouldBeSent = await notificationRepository.GetNotSentBy(
            DateTimeOffset.UtcNow,
            cancellationToken);

        foreach (Notification notification in notificationsShouldBeSent)
        {
            await notificator.SendNotification(notification, cancellationToken);
            notification.Send(DateTimeOffset.UtcNow);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
