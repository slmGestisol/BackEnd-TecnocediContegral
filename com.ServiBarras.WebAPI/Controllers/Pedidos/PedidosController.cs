using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Pedidos
{
    //[Route("api/[controller]")]
    [ApiController]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoBL _pedidoBL;

        public PedidosController(IPedidoBL pedidoBL)
        {
            this._pedidoBL = pedidoBL;
        }

        // GET: api/Pedidos
        [Route("api/getpedidos/{instalacionId}")]
        [HttpGet]
        public JsonResult GetPedidos(long instalacionId)
        {
            var pedidosList = this._pedidoBL.GetPedidos(instalacionId);
            JsonResult json = new JsonResult(pedidosList);
            return json;
        }

        [Route("api/GetPedidoDetalle/{pedidoId}")]
        [HttpGet]
        public JsonResult GetPedidoDetalle(long pedidoId)
        {
            var pedidosDetalleList = this._pedidoBL.GetPedidoDetalle(pedidoId);
            JsonResult json = new JsonResult(pedidosDetalleList);
            return json;
        }
        // GET: api/Pedidos/5
        [Route("api/getpedido/{pedidoId}")]
        [HttpGet]
        public async Task<JsonResult> GetPedido(long pedidoId)
        {
            var pedidosList = await this._pedidoBL.GetPedidoAsync(pedidoId);
            JsonResult json = new JsonResult(pedidosList);
            return json;
        }

        [Route("api/actualizarPedidoEstado")]
        [HttpPost]
        public JsonResult ActualizarPedidoEstado([FromBody] JObject parametrosPedidos)
        {
            var result = this._pedidoBL.ActualizarPedidoEstado(parametrosPedidos);
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }

        [Route("api/SetCargarPedidos")]
        [HttpPost]
        public JsonResult SetCargarPedidos()
        {
            var result = this._pedidoBL.SetCargarPedidos();
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }


    }
}
