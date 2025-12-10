using PedidosAPI.Application.DTOs;
using PedidosAPI.Domain;

namespace PedidosAPI.Application.Mappers
{
    public static class PedidoMapper
    {
        public static PedidoDTO ToDTO(this Pedido pedido)
        {
            return new PedidoDTO
            {
                Id = pedido.Id,
                Status = (int)pedido.Status,
                DataCriacao = pedido.DataCriacao,
                Total = pedido.Total,
                Itens = pedido.Itens.Select(i => i.ToDTO()).ToList()
            };
        }

        public static ItemPedidoDTO ToDTO(this ItemPedido item)
        {
            return new ItemPedidoDTO
            {
                Id = item.Id,
                ProdutoId = item.ProdutoId,
                NomeProduto = item.NomeProduto,
                Quantidade = item.Quantidade,
                PrecoUnitario = item.PrecoUnitario,
                Total = item.Total
            };
        }
    }
}
