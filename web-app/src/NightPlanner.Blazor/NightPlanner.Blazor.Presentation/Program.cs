using NightPlanner.Blazor.Presentation.ApiClients.Plans;
using NightPlanner.Blazor.Presentation.ApiServices.Contracts;
using NightPlanner.Blazor.Presentation.ApiServices.Implementations;
using NightPlanner.Blazor.Presentation.Components;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(x => x.DetailedErrors = true);

builder.Services.AddScoped<IJsInteractor, JsInteractor>();
builder.Services.AddScoped<ITelegramAuthenticationService, TelegramAuthenticationService>();

builder.Services.AddRefitClient<IPlansApi>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(builder.Configuration["ApplicationSettings:ApiPath"]!));

builder.Services.AddBlazorBootstrap();

var app = builder.Build();
    
app.Use(async (httpContext, next) =>
{
    var headers = httpContext.Request.Headers.ToList();
    await next.Invoke();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
