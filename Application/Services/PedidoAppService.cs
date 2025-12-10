using PedidosAPI.Application.DTOs;
using PedidosAPI.Application.Mappers;
using PedidosAPI.Domain;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.Application.Services
{
    public class PedidoAppService
    {
        private readonly IPedidoRepository _pedidoRepo;
        private readonly IProdutoRepository _produtoRepo;

        public PedidoAppService(IPedidoRepository pedidoRepo, IProdutoRepository produtoRepo)
        {
            _pedidoRepo = pedidoRepo;
            _produtoRepo = produtoRepo;
        }

        public PedidoDTO CriarPedido()
        {
            var pedido = new Pedido();
            _pedidoRepo.Adicionar(pedido);

            return pedido.ToDTO();
        }

        public PedidoDTO AdicionarItem(Guid pedidoId, AdicionarItemDTO dto)
        {
            var pedido = _pedidoRepo.ObterPorId(pedidoId)
                ?? throw new Exception("Pedido não encontrado.");

            var produto = _produtoRepo.ObterPorId(dto.ProdutoId)
                ?? throw new Exception("Produto não encontrado.");

            pedido.AdicionarItem(produto, dto.Quantidade);

            _pedidoRepo.Atualizar(pedido);

            return pedido.ToDTO();
        }

        public PedidoDTO Obter(Guid id)
        {
            var pedido = _pedidoRepo.ObterPorId(id)
                ?? throw new Exception("Pedido não encontrado.");

            return pedido.ToDTO();
        }

        public IEnumerable<PedidoDTO> Listar()
        {
            return _pedidoRepo.Listar().Select(p => p.ToDTO());
        }

        public void FecharPedido(Guid id)
        {
            var pedido = _pedidoRepo.ObterPorId(id)
                ?? throw new Exception("Pedido não encontrado.");

            pedido.Fechar();

            _pedidoRepo.Atualizar(pedido);
        }
    }
}