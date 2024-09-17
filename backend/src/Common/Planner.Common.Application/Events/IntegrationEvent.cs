namespace Planner.Common.Application.Events;

public abstract class IntegrationEvent : IIntegrationEvent
{
    protected IntegrationEvent(Guid id, DateTimeOffset occurredAt)
    {
        Id = id;
        OccurredAt = occurredAt;
    }

    public Guid Id { get; init; }

    public DateTimeOffset OccurredAt { get; init; }
}
