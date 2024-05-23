using Carter;
using TaskTracker.Core.Application;
using TaskTracker.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddPersistenceInfrastructure(builder.Configuration);

builder.Services.AddCarter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.EnsureDatabaseCreated();

app.MapCarter();

app.UseHttpsRedirection();

app.Run();