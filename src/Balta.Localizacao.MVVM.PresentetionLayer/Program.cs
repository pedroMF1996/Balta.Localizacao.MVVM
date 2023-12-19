using Balta.Localizacao.MVVM.Data;
using Balta.Localizacao.MVVM.PresentetionLayer.Components;
using Balta.Localizacao.MVVM.PresentetionLayer.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddWebAppConfiguration(builder.Configuration,builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseWebAppConfiguration(app.Environment);
app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
