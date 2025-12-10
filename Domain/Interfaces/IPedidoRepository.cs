namespace PedidosAPI.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido? ObterPorId(Guid id);
        IEnumerable<Pedido> Listar();
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
    }
}
