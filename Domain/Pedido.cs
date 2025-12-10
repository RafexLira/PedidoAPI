using PedidosAPI.Domain;
using PedidosAPI.Enums;

public class Pedido
{
    public Guid Id { get; private set; }
    public PedidoStatus Status { get; private set; }
    public DateTime DataCriacao { get; private set; }

    private readonly List<ItemPedido> _itens = new();
    public IReadOnlyCollection<ItemPedido> Itens => _itens;

    public Pedido()
    {
        Id = Guid.NewGuid();
        Status = PedidoStatus.Aberto;
        DataCriacao = DateTime.UtcNow;
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (Status != PedidoStatus.Aberto)
            throw new Exception("Pedido fechado.");

        var existente = _itens.FirstOrDefault(x => x.ProdutoId == produto.Id);

        if (existente == null)
            _itens.Add(new ItemPedido(produto, quantidade));
        else
            existente.AdicionarQuantidade(quantidade);
    }

    public void RemoverItem(Guid produtoId, int quantidade)
    {
        if (Status != PedidoStatus.Aberto)
            throw new Exception("Pedido fechado.");

        var item = _itens.FirstOrDefault(x => x.ProdutoId == produtoId);
        if (item == null) return;

        if (quantidade >= item.Quantidade)
            _itens.Remove(item);
        else
            item.RemoverQuantidade(quantidade);
    }

    public void Fechar()
    {
        if (!_itens.Any())
            throw new Exception("Pedido vazio.");

        Status = PedidoStatus.Fechado;
    }

    public decimal Total => _itens.Sum(x => x.Total);
}
