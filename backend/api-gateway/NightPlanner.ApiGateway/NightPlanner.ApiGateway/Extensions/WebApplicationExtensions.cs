using Ocelot.Middleware;
using Serilog;

namespace NightPlanner.ApiGateway.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        app.UseOcelot().Wait();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();

        return app;
    }
}