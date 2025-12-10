using PedidosAPI.Application.DTOs;
using PedidosAPI.Application.Mappers;
using PedidosAPI.Domain;
using PedidosAPI.Domain.Interfaces;

namespace PedidosAPI.Application.Services
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepo;

        public ProdutoAppService(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }

        public ProdutoDTO Criar(CriarProdutoDTO dto)
        {
            var produto = new Produto(dto.Nome, dto.Preco);
            _produtoRepo.Adicionar(produto);

            return produto.ToDTO();
        }

        public ProdutoDTO Obter(Guid id)
        {
            var produto = _produtoRepo.ObterPorId(id)
                ?? throw new Exception("Produto não encontrado.");

            return produto.ToDTO();
        }

        public IEnumerable<ProdutoDTO> Listar()
        {
            return _produtoRepo.Listar().Select(p => p.ToDTO());
        }
    }
}
