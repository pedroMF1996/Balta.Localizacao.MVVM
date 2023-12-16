using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Balta.Localizacao.MVVM.Core.Data
{
    public static class DatabaseMigrationExtension
    {
        public static void UseEnsuredDatabaseMigration<T>(this WebApplication app) where T : DbContext
        {
            var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<T>();

            dbContext.Database.Migrate();
        }
    }
}
