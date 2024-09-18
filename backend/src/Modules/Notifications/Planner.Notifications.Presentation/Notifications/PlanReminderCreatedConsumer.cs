using MassTransit;
using MediatR;
using Planner.Notifications.Application.Notifications.CreateNotification;
using Planner.Plans.IntegrationEvents;

namespace Planner.Notifications.Presentation.Notifications;

public sealed class PlanReminderCreatedConsumer(ISender sender) : IConsumer<PlanReminderCreatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<PlanReminderCreatedIntegrationEvent> context)
    {
        var command = new CreatePlanNotificationCommand(
            context.Message.CreatorUserId,
            context.Message.PlanName,
            context.Message.ScheduledAt,
            context.Message.ExternalId);
        await sender.Send(command, context.CancellationToken);
    }
}
