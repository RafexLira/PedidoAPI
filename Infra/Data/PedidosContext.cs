using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain;

namespace PedidosAPI.Infra.Data
{
    public class PedidosDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        public PedidosDbContext(DbContextOptions<PedidosDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosDbContext).Assembly);
        }
    }
}
