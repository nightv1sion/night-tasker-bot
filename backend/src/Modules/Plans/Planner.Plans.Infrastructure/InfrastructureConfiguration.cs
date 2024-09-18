using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Common.Infrastructure.Persistence.Interceptors;
using Planner.Plans.Application;
using Planner.Plans.Domain.Plans.Repositories;
using Planner.Plans.Infrastructure.Configurations;
using Planner.Plans.Infrastructure.Infrastructure;
using Planner.Plans.Infrastructure.Repositories.Plans;

namespace Planner.Plans.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string? databaseConnectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);

        services.AddDbContext<PlansDbContext>((serviceProvider, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Plans))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(serviceProvider.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.RegisterRepositories();

        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPlanReadRepository, PlanReadRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
    }
}
