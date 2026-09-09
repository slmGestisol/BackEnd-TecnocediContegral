using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.WebAPI.Hubs;
using com.ServiBarras.WebAPI.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace com.ServiBarras.WebAPI.Controllers.Reabastecimiento
{
    [ApiController]
    public class ReabastecimientoController : ControllerBase
    {
        private readonly IReabastecimientoBL _reabastecimientoBL;
        private readonly IHubContext<WmsHub> _hubContext;
        private readonly IReabastecimientoState _state;

        public ReabastecimientoController(
            IReabastecimientoBL reabastecimientoBL,
            IHubContext<WmsHub> hubContext,
            IReabastecimientoState state)
        {
            this._reabastecimientoBL = reabastecimientoBL;
            this._hubContext = hubContext;
            this._state = state;
        }

        // GET: api/getReabastecimientoSaldoSugeridoByProductoId/{productoId}/{instalacionId}
        [Route("api/getReabastecimientoSaldoSugeridoByProductoId/{productoId}/{instalacionId}")]
        [HttpGet]
        public JsonResult GetReabastecimientoSaldoSugeridoByProductoId(int productoId, long instalacionId)
        {
            DataSet result = this._reabastecimientoBL.ObtenerSaldoSugeridoByProductoId(productoId, instalacionId);
            JsonResult json = new JsonResult(result);
            if (result == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;
        }

        // GET: api/getUbicacionesPorReabastecerByProductoId/{productoId}/{instalacionId}
        [Route("api/getUbicacionesPorReabastecerByProductoId/{productoId}/{instalacionId}")]
        [HttpGet]
        public JsonResult GetUbicacionesPorReabastecerByProductoId(int productoId, long instalacionId)
        {
            DataSet result = this._reabastecimientoBL.ObtenerUbicacionesPorReabastecerByProductoId(productoId, instalacionId);
            JsonResult json = new JsonResult(result);
            if (result == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;
        }

        // POST: api/refrescarReabastecimiento
        // Ejecuta bajo demanda sp_GET_ReabastecimientoData (misma lógica que el BackgroundService):
        // recalcula el hash y, si cambió respecto al último snapshot, actualiza el estado de la sala
        // y notifica a Room_Reabastecimiento con el evento "ReabastecimientoActualizado".
        [Route("api/refrescarReabastecimiento")]
        [HttpPost]
        public async Task<JsonResult> RefrescarReabastecimiento()
        {
            try
            {
                IReadOnlyList<ReabastecimientoItemDto> data =
                    await this._reabastecimientoBL.ObtenerReabastecimientoAsync();

                string hash = ReabastecimientoHasher.Calcular(data);

                bool actualizado = !string.Equals(hash, this._state.UltimoHash, StringComparison.Ordinal);

                // Sólo se guarda el snapshot y se notifica a la sala cuando los datos cambiaron.
                if (actualizado)
                {
                    this._state.GuardarSnapshot(data, hash);

                    await this._hubContext.Clients
                        .Group(WmsHub.RoomReabastecimiento)
                        .SendAsync("ReabastecimientoActualizado", data);
                }

                JsonResult json = new JsonResult(new
                {
                    actualizado,
                    totalRegistros = data.Count,
                    hash
                });
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                // El logging del error ya lo realiza el DAL (LogEvent). Aquí sólo se traduce a 500.
                JsonResult json = new JsonResult("Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)");
                json.StatusCode = 500;
                return json;
            }
        }
    }
}
