using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Balta.Localizacao.MVVM.Core.Data
{
    public static class DatabaseMigrationExtension
    {
        public static void UseEnsuredDatabaseMigration<T>(this IApplicationBuilder app) where T : DbContext
        {
            var dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<T>();

            dbContext.Database.Migrate();
        }
    }
}
