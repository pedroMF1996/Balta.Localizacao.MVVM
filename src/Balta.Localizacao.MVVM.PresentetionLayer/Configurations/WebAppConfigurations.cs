using Microsoft.EntityFrameworkCore;
using Balta.Localizacao.MVVM.Data;
using Balta.Localizacao.MVVM.Core.Data;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Configurations
{
    public static class WebAppConfigurations
    {
        public static void AddWebAppConfiguration(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            services.AddIdentityConfiguration(configuration);

            services.AddDbContext<LocalizacaoDbContex>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddServices();
            services.AddCascadingAuthenticationState();

            services.AddRazorPages();
            services.AddRazorComponents()
                    .AddInteractiveServerComponents();
            services.AddFluentUIComponents();

            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddCascadingAuthenticationState();
        }

        public static void UseWebAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.UseEnsureDatabaseMigration<AutenticationDbContext>();
            app.UseEnsureDatabaseMigration<LocalizacaoDbContex>();
        }
    }
}
