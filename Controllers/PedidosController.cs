using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.DTOs;
using PedidosAPI.Application.Services;

namespace PedidosAPI.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoAppService _app;

        public PedidosController(PedidoAppService app)
        {
            _app = app;
        }

        [HttpPost]
        public ActionResult<PedidoDTO> Criar()
            => Ok(_app.CriarPedido());

        [HttpPost("{id}/itens")]
        public ActionResult<PedidoDTO> Add(Guid id, AdicionarItemDTO dto)
            => Ok(_app.AdicionarItem(id, dto));

        [HttpGet("{id}")]
        public ActionResult<PedidoDTO> Obter(Guid id)
            => Ok(_app.Obter(id));

        [HttpGet]
        public ActionResult<IEnumerable<PedidoDTO>> Listar()
            => Ok(_app.Listar());

        [HttpPost("{id}/fechar")]
        public IActionResult Fechar(Guid id)
        {
            _app.FecharPedido(id);
            return NoContent();
        }
    }

}
