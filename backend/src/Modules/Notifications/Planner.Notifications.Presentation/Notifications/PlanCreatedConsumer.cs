using MassTransit;
using MediatR;
using Planner.Notifications.Application.Notifications.CreateNotification;
using Planner.Plans.IntegrationEvents;

namespace Planner.Notifications.Presentation.Notifications;

public sealed class PlanCreatedConsumer(ISender sender) : IConsumer<PlanCreatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<PlanCreatedIntegrationEvent> context)
    {
        var command = new CreatePlanNotificationCommand(
            context.Message.CreatorUserId,
            context.Message.PlanName,
            context.Message.ScheduledAt);
        await sender.Send(command, context.CancellationToken);
    }
}
