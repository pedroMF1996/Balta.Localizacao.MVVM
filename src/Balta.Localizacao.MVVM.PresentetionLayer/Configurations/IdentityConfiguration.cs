using Balta.Localizacao.MVVM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Configurations
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services,
                                                         IConfiguration configuration)
        {
            services.AddDbContext<AutenticationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<AutenticationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
