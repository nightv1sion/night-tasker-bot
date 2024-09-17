using Planner.Common.Application.Messaging;

namespace Planner.Notifications.Application.Notifications.CreateNotification;

public sealed record CreatePlanNotificationCommand(
    int DestinationUserId,
    string PlanName,
    DateTimeOffset ScheduledAt)
    : ICommand;
