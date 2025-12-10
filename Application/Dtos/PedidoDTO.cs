namespace PedidosAPI.Application.DTOs
{
    public class PedidoDTO
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ItemPedidoDTO> Itens { get; set; } = new();
        public decimal Total { get; set; }
    }

    public class ItemPedidoDTO
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
