using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Common.Presentation.Endpoints;
using Planner.Plans.Infrastructure;

namespace Planner.Plans.Presentation;

public static class PlansModule
{
    public static IServiceCollection AddPlansModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(AssemblyReference.Assembly);

        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumers(AssemblyReference.Assembly);
    }
}
