using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Balta.Localizacao.MVVM.Data
{
    public class LocalizacaoDbContex : DbContext, IUnitOfWork
    {
        public LocalizacaoDbContex(DbContextOptions options) : base(options)
        {
        }

        public DbSet<IbgeModel> Ibges { get; set; }
              

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.HasSequence<int>("IX_IBGE_ID");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocalizacaoDbContex).Assembly);
        }
    }
}
