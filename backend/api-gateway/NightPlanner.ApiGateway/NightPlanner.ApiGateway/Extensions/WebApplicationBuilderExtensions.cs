using System.Text;
using Ocelot.DependencyInjection;
using Serilog;

namespace NightPlanner.ApiGateway.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration)
            => configuration.ReadFrom.Configuration(context.Configuration));

        builder.ConfigureOcelot();
        
        builder.Services.AddOcelot(builder.Configuration);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static void ConfigureOcelot(this WebApplicationBuilder builder)
    {
        string ocelotPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            builder.Configuration["Ocelot:SourceFile"]!);
        string host = builder.Configuration["Ocelot:Host"]!;

        MemoryStream ocelotJson = BuildOcelotJson(ocelotPath, host);

        builder.Configuration.AddJsonStream(ocelotJson);
    }

    private static MemoryStream BuildOcelotJson(
        string ocelotPath,
        string host)
    {
        string ocelotJson = File.ReadAllText(ocelotPath);
        ocelotJson = ocelotJson.Replace("{HOST}", host);
        return new MemoryStream(Encoding.UTF8.GetBytes(ocelotJson));
    }
}