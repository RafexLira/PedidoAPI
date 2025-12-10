namespace PedidosAPI.Domain
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        private Produto() { }

        public Produto(string nome, decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
        }

        public void AtualizarPreco(decimal novoPreco) => Preco = novoPreco;
        public void AtualizarNome(string nome) => Nome = nome;
    }

}
