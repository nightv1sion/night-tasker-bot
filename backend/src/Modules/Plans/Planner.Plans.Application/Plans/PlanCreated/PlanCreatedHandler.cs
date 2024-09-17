using Planner.Common.Application.Events;
using Planner.Common.Domain.Core.Events;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.IntegrationEvents;

namespace Planner.Plans.Application.Plans.PlanCreated;

internal sealed class PlanCreatedHandler(
    IEventBus bus)
    : IDomainEventHandler<PlanCreatedDomainEvent>
{
    public async Task Handle(PlanCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await bus.PublishAsync(
            new PlanCreatedIntegrationEvent(
                Guid.NewGuid(),
                DateTimeOffset.Now,
                notification.CreatorUserId,
                notification.Name,
                notification.ScheduledAt), cancellationToken);
    }
}
