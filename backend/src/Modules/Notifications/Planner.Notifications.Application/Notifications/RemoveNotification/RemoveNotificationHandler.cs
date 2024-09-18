using Planner.Common.Application.Messaging;
using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Application.Notifications.RemoveNotification;

internal sealed class RemoveNotificationHandler(
    INotificationRepository notificationRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveNotificationCommand>
{
    public async Task Handle(RemoveNotificationCommand request, CancellationToken cancellationToken)
    {
        Notification? notification = await notificationRepository.TryGetBy(request.ExternalId, cancellationToken);

        if (notification is null)
        {
            throw new InvalidOperationException();
        }
        
        notificationRepository.Remove(notification);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
