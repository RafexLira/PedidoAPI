namespace PedidosAPI.Application.DTOs
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    public class CriarProdutoDTO
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
