﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Notifications.Application;
using Planner.Notifications.Application.Abstractions;
using Planner.Notifications.Domain.Notifications;
using Planner.Notifications.Infrastructure.Configurations;
using Planner.Notifications.Infrastructure.Infrastructure;
using Planner.Notifications.Infrastructure.Notifications;
using Planner.Notifications.Infrastructure.Repositories.Notifications;
using Planner.Notifications.Infrastructure.Telegram;
using Quartz;

namespace Planner.Notifications.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string? databaseConnectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);

        services.AddDbContext<NotificationsDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Notifications))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors());

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITelegramNotificator, TelegramNotificator>();

        services.AddQuartz(configurator =>
        {
            configurator.RegisterCheckScheduledNotificationsJob();
        });

        services.RegisterRepositories();

        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<INotificationRepository, NotificationRepository>();
    }
}
