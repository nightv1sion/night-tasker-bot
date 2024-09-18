using MediatR;
using Planner.Notifications.Application.Notifications.SendNotifications;
using Quartz;

namespace Planner.Notifications.Infrastructure.Notifications;

[DisallowConcurrentExecution]
public class CheckScheduledNotificationsJob(ISender sender) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        SendNotificationsCommand sendNotificationsCommand = new();
        await sender.Send(sendNotificationsCommand);
    }
}
