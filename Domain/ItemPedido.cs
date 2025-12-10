namespace PedidosAPI.Domain
{
    public class ItemPedido
    {
        public Guid Id { get; private set; } 
        public Guid ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Total => Quantidade * PrecoUnitario;

        private ItemPedido() { }

        public ItemPedido(Produto produto, int quantidade)
        {      
            ProdutoId = produto.Id;
            NomeProduto = produto.Nome;
            PrecoUnitario = produto.Preco;
            Quantidade = quantidade;
        }

        public void AdicionarQuantidade(int qtd) => Quantidade += qtd;
        public void RemoverQuantidade(int qtd) => Quantidade -= qtd;
    }
}