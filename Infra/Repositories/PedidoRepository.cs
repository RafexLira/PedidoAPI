using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Interfaces;
using PedidosAPI.Infra.Data;

namespace PedidosAPI.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosDbContext _context;

        public PedidoRepository(PedidosDbContext context)
        {
            _context = context;
        }

        public Pedido? ObterPorId(Guid id)
            => _context.Pedidos
                       .Include(x => x.Itens)
                       .FirstOrDefault(x => x.Id == id);

        public IEnumerable<Pedido> Listar()
            => _context.Pedidos
                       .Include(x => x.Itens)
                       .ToList();

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }
    }

}

