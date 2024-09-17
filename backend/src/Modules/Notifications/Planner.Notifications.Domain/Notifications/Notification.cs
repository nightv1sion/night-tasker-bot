using Planner.Common.Domain.Core.Primitives;

namespace Planner.Notifications.Domain.Notifications;

public sealed class Notification : AggregateRoot
{
    public required string Message { get; init; }
    
    public required int DestinationUserId { get; init; }

    public required DateTimeOffset ScheduledAt { get; init; }

    public DateTimeOffset? SentAt { get; set; }

    public static Notification Schedule(
        string message,
        int destinationUserId,
        DateTimeOffset scheduledAt)
    {
        return new Notification
        {
            Message = message,
            DestinationUserId = destinationUserId,
            ScheduledAt = scheduledAt
        };
    }
}
