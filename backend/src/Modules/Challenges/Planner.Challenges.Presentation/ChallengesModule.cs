using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Challenges.Presentation.Endpoints.ChallengeMessages;
using Planner.Challenges.Presentation.Endpoints.Challenges;

namespace Planner.Challenges.Presentation;

public static class ChallengesModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        ChallengeEndpoints.AddRoutes(app);
        ChallengeMessageEndpoints.AddRoutes(app);
    }

    public static IServiceCollection AddChallengesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Common.Infrastructure.InfrastructureConfiguration.AddInfrastructure(services, configuration.GetConnectionString("Database")!);

        Infrastructure.InfrastructureConfiguration.AddInfrastructure(services, configuration);

        return services;
    }
}
