namespace PedidosAPI.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Produto? ObterPorId(Guid id);
        IEnumerable<Produto> Listar();
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
