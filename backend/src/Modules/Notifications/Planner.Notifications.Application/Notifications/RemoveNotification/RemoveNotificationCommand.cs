using Planner.Common.Application.Messaging;

namespace Planner.Notifications.Application.Notifications.RemoveNotification;

public sealed record RemoveNotificationCommand(Guid ExternalId) : ICommand;
