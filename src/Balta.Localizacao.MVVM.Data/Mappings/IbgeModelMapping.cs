using Balta.Localizacao.MVVM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Balta.Localizacao.MVVM.Data.Mappings
{
    public class IbgeModelMapping : IEntityTypeConfiguration<IbgeModel>
    {
        public void Configure(EntityTypeBuilder<IbgeModel> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PK_IBGE");

            builder.Property(x => x.Id)
                .HasColumnType("char")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(x => x.City) 
                .HasColumnType("nvarchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnType("char")
                .HasMaxLength (2)
                .IsRequired();

            builder.HasIndex(x => x.Id)
                .IsUnique()
                .HasName("IX_IBGE_Id");

            builder.HasIndex(x => x.City)
                .IsUnique()
                .HasName("IX_IBGE_City");
            
            builder.HasIndex(x => x.State)
                .IsUnique()
                .HasName("IX_IBGE_State");

            builder.ToTable("IBGE");
        }
    }
}
