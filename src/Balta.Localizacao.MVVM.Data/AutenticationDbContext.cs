using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Balta.Localizacao.MVVM.Data
{
    public class AutenticationDbContext : IdentityDbContext
    {
        public AutenticationDbContext(DbContextOptions<AutenticationDbContext> options) : base(options)
        {
        }
    }
}
