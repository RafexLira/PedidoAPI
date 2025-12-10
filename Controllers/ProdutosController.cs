using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.DTOs;
using PedidosAPI.Application.Services;

namespace PedidosAPI.Application.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoAppService _app;

        public ProdutosController(ProdutoAppService app)
        {
            _app = app;
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Criar(CriarProdutoDTO dto)
            => Ok(_app.Criar(dto));

        [HttpGet("{id}")]
        public ActionResult<ProdutoDTO> Obter(Guid id)
            => Ok(_app.Obter(id));

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> Listar()
            => Ok(_app.Listar());
    }
}
