using Quartz;

namespace Planner.Notifications.Infrastructure.Notifications;

internal static class DependencyInjection
{
    public static void RegisterCheckScheduledNotificationsJob(this IServiceCollectionQuartzConfigurator configurator)
    {
        string jobName = typeof(CheckScheduledNotificationsJob).FullName!;
        
        configurator
            .AddJob<CheckScheduledNotificationsJob>(configure => configure.WithIdentity(jobName))
            .AddTrigger(configure =>
                configure
                    .ForJob(jobName)
                    .WithSimpleSchedule(schedule =>
                        schedule.WithIntervalInSeconds(60).RepeatForever()));
    }
}
