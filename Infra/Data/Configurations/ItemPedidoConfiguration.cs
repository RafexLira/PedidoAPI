using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosAPI.Domain;

namespace PedidosAPI.Infra.Data.Configurations
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeProduto)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PrecoUnitario)
                    .HasConversion<double>();

            builder.Property(x => x.Quantidade)
                .IsRequired();
        }
    }

}
