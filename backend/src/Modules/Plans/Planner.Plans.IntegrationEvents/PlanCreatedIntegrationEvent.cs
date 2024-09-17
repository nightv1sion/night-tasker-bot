using Planner.Common.Application.Events;

namespace Planner.Plans.IntegrationEvents;

public sealed class PlanCreatedIntegrationEvent : IntegrationEvent
{
    public PlanCreatedIntegrationEvent(
        Guid id,
        DateTimeOffset occurredAt,
        int creatorUserId,
        string planName,
        DateTimeOffset scheduledAt)
        : base(
            id,
            occurredAt)
    {
        CreatorUserId = creatorUserId;
        PlanName = planName;
        ScheduledAt = scheduledAt;
    }

    public int CreatorUserId { get; init; }

    public string PlanName { get; init; }

    public DateTimeOffset ScheduledAt { get; set; }
}
