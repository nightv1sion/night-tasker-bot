using Planner.Common.Domain.Core.Events;

namespace Planner.Plans.Domain.Plans.Entities;

public sealed class PlanCreatedDomainEvent(int creatorUserId, string name, DateTimeOffset scheduledAt) : DomainEvent
{
    public required int CreatorUserId { get; init; } = creatorUserId;
    
    public required string Name { get; init; } = name;

    public required DateTimeOffset ScheduledAt { get; init; } = scheduledAt;
}
