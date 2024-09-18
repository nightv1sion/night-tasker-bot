using Planner.Common.Domain.Core.Events;

namespace Planner.Plans.Domain.Plans.Entities;

public sealed class PlanReminderCreatedDomainEvent(
    long creatorUserId,
    string planName,
    DateTimeOffset scheduledAt,
    Guid notificationId)
    : DomainEvent
{
    public Guid NotificationId { get; set; } = notificationId;
    
    public long CreatorUserId { get; init; } = creatorUserId;
    
    public string PlanName { get; init; } = planName;

    public DateTimeOffset ScheduledAt { get; init; } = scheduledAt;
}
