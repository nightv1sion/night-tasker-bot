using Planner.Common.Application.Events;

namespace Planner.Plans.IntegrationEvents;

public sealed class PlanReminderRemovedIntegrationEvent : IntegrationEvent
{
    public PlanReminderRemovedIntegrationEvent(Guid reminderId)
    {
        ReminderId = reminderId;
    }
    
    public Guid ReminderId { get; init; }
}
