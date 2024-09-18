using Planner.Common.Application.Events;
using Planner.Common.Domain.Core.Events;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.IntegrationEvents;

namespace Planner.Plans.Application.Plans.PlanCreated;

internal sealed class PlanReminderCreatedHandler(
    IEventBus bus)
    : IDomainEventHandler<PlanReminderCreatedDomainEvent>
{
    public async Task Handle(PlanReminderCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(
            new PlanReminderCreatedIntegrationEvent(
                Guid.NewGuid(),
                DateTimeOffset.Now,
                notification.CreatorUserId,
                notification.PlanName,
                notification.ScheduledAt,
                notification.NotificationId), cancellationToken);
    }
}
