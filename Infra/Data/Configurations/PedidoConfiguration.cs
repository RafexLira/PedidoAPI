using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosAPI.Domain;

namespace PedidosAPI.Infra.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();

            builder.HasMany(x => x.Itens)
                .WithOne()
                .HasForeignKey("PedidoId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Itens)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(x => x.Total);
        }
    }

}
