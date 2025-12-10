using PedidosAPI.Domain;
using PedidosAPI.Domain.Interfaces;
using PedidosAPI.Infra.Data;

namespace PedidosAPI.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidosDbContext _context;

        public ProdutoRepository(PedidosDbContext context)
        {
            _context = context;
        }

        public Produto? ObterPorId(Guid id)
            => _context.Produtos.Find(id);

        public IEnumerable<Produto> Listar()
            => _context.Produtos.ToList();

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
    }

}
