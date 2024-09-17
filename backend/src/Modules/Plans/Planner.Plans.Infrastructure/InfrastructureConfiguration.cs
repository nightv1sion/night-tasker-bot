using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        services.AddDbContext<PlansDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Plans))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors());

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

    public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        PlansDbContext dbContext = scope.ServiceProvider.GetRequiredService<PlansDbContext>();
        dbContext.Database.Migrate();
    }
}
