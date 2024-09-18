using Planner.Common.Application.Messaging;
using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Application.Notifications.CreateNotification;

internal sealed class CreatePlanNotificationHandler(
    INotificationRepository notificationRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePlanNotificationCommand>
{
    public async Task Handle(CreatePlanNotificationCommand request, CancellationToken cancellationToken)
    {
        string notificationMessage = $"Настало время сделать план: {request.PlanName}";
        var notification = Notification.Schedule(
            notificationMessage,
            request.DestinationUserId,
            request.ScheduledAt,
            request.ExternalId);
        
        await notificationRepository.InsertAsync(notification, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
