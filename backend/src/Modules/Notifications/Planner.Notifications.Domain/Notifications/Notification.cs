using Planner.Common.Domain.Core.Primitives;

namespace Planner.Notifications.Domain.Notifications;

public sealed class Notification : AggregateRoot
{
    public required string Message { get; init; }
    
    public required long DestinationUserId { get; init; }

    public required DateTimeOffset ScheduledAt { get; init; }

    public DateTimeOffset? SentAt { get; set; }

    public required Guid ExternalId { get; init; }

    public static Notification Schedule(
        string message,
        long destinationUserId,
        DateTimeOffset scheduledAt,
        Guid externalId)
    {
        return new Notification
        {
            Message = message,
            DestinationUserId = destinationUserId,
            ScheduledAt = scheduledAt,
            ExternalId = externalId
        };
    }

    public void Send(DateTimeOffset sentAt)
    {
        SentAt = sentAt;
    }
}
