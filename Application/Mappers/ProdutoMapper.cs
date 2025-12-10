using PedidosAPI.Application.DTOs;
using PedidosAPI.Domain;

namespace PedidosAPI.Application.Mappers
{
    public static class ProdutoMapper
    {
        public static ProdutoDTO ToDTO(this Produto produto)
        {
            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }
    }
}
