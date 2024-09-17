using HealthChecks.UI.Client;
using Planner.Api.Extensions;
using Planner.Api.Middlewares;
using Planner.Plans.Infrastructure;
using Planner.Plans.Presentation;
using Planner.Common.Application;
using Planner.Common.Infrastructure;
using Planner.Common.Infrastructure.Events;
using Planner.Common.Presentation.Endpoints;
using Planner.Notifications.Presentation;
using Planner.TelegramIntegration;
using Serilog;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([
    Planner.Plans.Application.AssemblyReference.Assembly, 
    Planner.Notifications.Application.AssemblyReference.Assembly]);

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
string redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

RabbitMqSettings rabbitMqSettings = builder.Configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>()!;

builder.Services.AddInfrastructure(
    [PlansModule.ConfigureConsumers, NotificationsModule.ConfigureConsumers],
    rabbitMqSettings,
    databaseConnectionString,
    redisConnectionString);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

builder.Services
    .AddPlansModule(builder.Configuration)
    .AddNotificationsModule(builder.Configuration)
    .AddTelegramIntegrationModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();

app.MapHealthChecks("health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.MapEndpoints();

app.Run();
