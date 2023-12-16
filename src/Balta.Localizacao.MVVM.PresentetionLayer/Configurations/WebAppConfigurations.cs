﻿using Balta.Localizacao.MVVM.Data;
using Balta.Localizacao.MVVM.Core.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Configurations
{
    public static class WebAppConfigurations
    {
        public static void AddWebAppConfiguration(this IServiceCollection services,
                                                    IConfiguration configuration,
                                                    IWebHostEnvironment environment)
        {
            services.AddIdentityConfiguration(configuration);
            
            services.AddRazorComponents()
                    .AddInteractiveServerComponents();
        }

        public static void UseWebAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (!environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            var supportCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportCultures,
                SupportedUICultures = supportCultures,
            });

            app.UseEnsuredDatabaseMigration<AutenticationDbContext>();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}