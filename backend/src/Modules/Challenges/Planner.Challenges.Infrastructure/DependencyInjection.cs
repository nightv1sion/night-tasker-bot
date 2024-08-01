using Challenges.Application.Abstractions.Data;
using Challenges.Domain.ChallengeMessages.Repositories;
using Challenges.Domain.Challenges.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Challenges.Infrastructure.Abstractions;
using Planner.Challenges.Infrastructure.Infrastructure;
using Planner.Challenges.Infrastructure.Repositories.ChallengeMessages;
using Planner.Challenges.Infrastructure.Repositories.Challenges;
using TaskTracker.Infrastructure.Persistence.Repositories;

namespace Planner.Challenges.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);

        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(databaseConnectionString));

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
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}