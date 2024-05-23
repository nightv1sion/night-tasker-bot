using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Core.Application.Abstractions.Data;
using TaskTracker.Core.Domain.Challenges.Repositories;
using TaskTracker.Infrastructure.Persistence.Abstractions;
using TaskTracker.Infrastructure.Persistence.Infrastructure;
using TaskTracker.Infrastructure.Persistence.Repositories;

namespace TaskTracker.Infrastructure.Persistence;

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
        
        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChallengeReadRepository, ChallengeReadRepository>();
        services.AddScoped<IChallengeWriteRepository, ChallengeWriteRepository>();
    }
    
    public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}