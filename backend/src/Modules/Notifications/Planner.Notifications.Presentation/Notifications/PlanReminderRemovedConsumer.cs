using MassTransit;
using MediatR;
using Planner.Notifications.Application.Notifications.RemoveNotification;
using Planner.Plans.IntegrationEvents;

namespace Planner.Notifications.Presentation.Notifications;

public sealed class PlanReminderRemovedConsumer(ISender sender) : IConsumer<PlanReminderRemovedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<PlanReminderRemovedIntegrationEvent> context)
    {
        var command = new RemoveNotificationCommand(context.Message.ReminderId);
        await sender.Send(command, context.CancellationToken);
    }
}
