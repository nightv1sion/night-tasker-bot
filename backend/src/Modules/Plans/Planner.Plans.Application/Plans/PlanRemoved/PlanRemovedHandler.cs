using MediatR;
using Planner.Common.Application.Events;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.IntegrationEvents;

namespace Planner.Plans.Application.Plans.PlanRemoved;

internal sealed class PlanRemovedHandler(
    IEventBus eventBus) : INotificationHandler<PlanRemovedDomainEvent>
{
    public async Task Handle(PlanRemovedDomainEvent notification, CancellationToken cancellationToken)
    {
        IEnumerable<PlanReminderRemovedIntegrationEvent> messages = notification.ReminderIds
            .Select(reminderId => new PlanReminderRemovedIntegrationEvent(reminderId));
        await eventBus.PublishBatchAsync(messages, cancellationToken);
    }
}
