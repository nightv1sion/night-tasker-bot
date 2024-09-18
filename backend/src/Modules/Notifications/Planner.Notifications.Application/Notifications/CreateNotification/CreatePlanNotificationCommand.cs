using Planner.Common.Application.Messaging;

namespace Planner.Notifications.Application.Notifications.CreateNotification;

public sealed record CreatePlanNotificationCommand(
    long DestinationUserId,
    string PlanName,
    DateTimeOffset ScheduledAt,
    Guid ExternalId)
    : ICommand;
