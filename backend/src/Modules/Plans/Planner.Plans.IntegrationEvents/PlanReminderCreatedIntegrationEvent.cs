using Planner.Common.Application.Events;

namespace Planner.Plans.IntegrationEvents;

public sealed class PlanReminderCreatedIntegrationEvent : IntegrationEvent
{
    public PlanReminderCreatedIntegrationEvent(
        Guid id,
        DateTimeOffset occurredAt,
        long creatorUserId,
        string planName,
        DateTimeOffset scheduledAt,
        Guid externalId)
        : base(
            id,
            occurredAt)
    {
        CreatorUserId = creatorUserId;
        PlanName = planName;
        ScheduledAt = scheduledAt;
        ExternalId = externalId;
    }

    public long CreatorUserId { get; init; }

    public string PlanName { get; init; }

    public DateTimeOffset ScheduledAt { get; init; }

    public Guid ExternalId { get; init; }
}
