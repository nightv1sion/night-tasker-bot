using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Challenges.Application.Abstractions.Data;
using Planner.Challenges.Domain.ChallengeMessages.Repositories;
using Planner.Challenges.Domain.Challenges.Repositories;
using Planner.Challenges.Infrastructure.Infrastructure;
using Planner.Challenges.Infrastructure.Repositories.ChallengeMessages;
using Planner.Challenges.Infrastructure.Repositories.Challenges;

namespace Planner.Challenges.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string? databaseConnectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);

        services.AddDbContext<ChallengesDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, "challenges"))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.RegisterRepositories();

        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChallengeReadRepository, ChallengeReadRepository>();
        services.AddScoped<IChallengeWriteRepository, ChallengeWriteRepository>();

        services.AddScoped<IChallengeMessageReadRepository, ChallengeMessageReadRepository>();
        services.AddScoped<IChallengeMessageWriteRepository, ChallengeMessageWriteRepository>();
    }

    public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        ChallengesDbContext dbContext = scope.ServiceProvider.GetRequiredService<ChallengesDbContext>();
        dbContext.Database.Migrate();
    }
}
