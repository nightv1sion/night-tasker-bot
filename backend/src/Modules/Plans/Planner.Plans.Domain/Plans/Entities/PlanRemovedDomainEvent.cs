using Planner.Common.Domain.Core.Events;

namespace Planner.Plans.Domain.Plans.Entities;

public sealed class PlanRemovedDomainEvent(
    IReadOnlyCollection<Guid> reminderIds)
    : DomainEvent
{
    public IReadOnlyCollection<Guid> ReminderIds { get; init; } = reminderIds;
}
