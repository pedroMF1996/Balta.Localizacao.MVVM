using Balta.Localizacao.MVVM.PresentetionLayer.Components;
using Balta.Localizacao.MVVM.PresentetionLayer.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
// Add services to the container.

builder.Services.AddWebAppConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseWebAppConfiguration(app.Environment);
app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
builder.WebHost.UseStaticWebAssets();

app.Run();
