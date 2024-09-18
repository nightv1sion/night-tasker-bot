using Microsoft.Extensions.DependencyInjection;
using Planner.Notifications.Application.ApplicationServices;

namespace Planner.Notifications.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotificator, Notificator>();

        return services;
    }
}
