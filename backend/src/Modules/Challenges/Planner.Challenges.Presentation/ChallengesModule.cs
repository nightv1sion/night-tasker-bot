using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Common.Presentation.Endpoints;

namespace Planner.Challenges.Presentation;

public static class ChallengesModule
{
    public static IServiceCollection AddChallengesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Infrastructure.InfrastructureConfiguration.AddInfrastructure(services, configuration);

        services.AddEndpoints(AssemblyReference.Assembly);

        return services;
    }
}
