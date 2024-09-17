using Planner.Notifications.Domain.Notifications;

namespace Planner.Notifications.Infrastructure.Repositories.Notifications;

internal sealed class NotificationRepository(
    NotificationsDbContext dbContext)
    : GenericRepository<Notification>(dbContext), INotificationRepository;
