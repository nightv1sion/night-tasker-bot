using HealthChecks.UI.Client;
using Planner.Api.Extensions;
using Planner.Api.Middlewares;
using Planner.Plans.Infrastructure;
using Planner.Plans.Presentation;
using Planner.Common.Application;
using Planner.Common.Infrastructure;
using Planner.Common.Presentation.Endpoints;
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

builder.Services.AddApplication([Planner.Plans.Application.AssemblyReference.Assembly]);

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
string redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

builder.Services.AddInfrastructure(
    databaseConnectionString,
    redisConnectionString);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

builder.Services
    .AddPlansModule(builder.Configuration)
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
