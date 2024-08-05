using Microsoft.EntityFrameworkCore;
using Planner.Challenges.Application.Abstractions.Data;
using Planner.Challenges.Presentation.Endpoints.ChallengeMessages;
using Planner.Challenges.Presentation.Endpoints.Challenges;
using Planner.Common.Infrastructure;

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
        InfrastructureConfiguration.AddInfrastructure(services, configuration.GetConnectionString("Database")!);

        return services;
    }
}
