using Balta.Localizacao.MVVM.PresentetionLayer.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Balta.Localizacao.MVVM.Data
{
    public class AutenticationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public AutenticationDbContext(DbContextOptions<AutenticationDbContext> options) : base(options)
        {
        }
    }
}
