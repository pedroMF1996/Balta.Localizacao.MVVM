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
                .IsRequired()
                .HasColumnOrder(1);

			builder.HasIndex(x => x.Id)
				.HasName("IX_IBGE_Id");

			builder.Property(x => x.State)
                .HasColumnType("char")
                .HasMaxLength (2)
				.HasDefaultValue(null)
				.HasColumnOrder(2);

            builder.HasIndex(x => x.State)
                .HasName("IX_IBGE_State");

			builder.Property(x => x.City)
				.HasColumnType("nvarchar")
				.HasMaxLength(80)
                .HasDefaultValue(null)
				.HasColumnOrder(3);

			builder.HasIndex(x => x.City)
				.HasName("IX_IBGE_City");

			builder.ToTable("IBGE");
        }
    }
}
