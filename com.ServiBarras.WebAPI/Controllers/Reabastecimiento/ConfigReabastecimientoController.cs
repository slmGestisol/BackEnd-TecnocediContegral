using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.WebAPI.Hubs;
using com.ServiBarras.WebAPI.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace com.ServiBarras.WebAPI.Controllers.Reabastecimiento
{
    /// <summary>
    /// Parametrización del proceso de reabastecimiento (maestro
    /// ConfigReabastecimientoProducto + detalle ConfigReabastecimientoUbicacion).
    /// Tras guardar o inactivar dispara el mismo recálculo/notificación del hub
    /// que api/refrescarReabastecimiento para que el panel en tiempo real
    /// refleje la nueva parametrización.
    /// </summary>
    [ApiController]
    public class ConfigReabastecimientoController : ControllerBase
    {
        private const string MensajeErrorServicio = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";

        private readonly IConfigReabastecimientoBL _configReabastecimientoBL;
        private readonly IReabastecimientoBL _reabastecimientoBL;
        private readonly IHubContext<WmsHub> _hubContext;
        private readonly IReabastecimientoState _state;

        public ConfigReabastecimientoController(
            IConfigReabastecimientoBL configReabastecimientoBL,
            IReabastecimientoBL reabastecimientoBL,
            IHubContext<WmsHub> hubContext,
            IReabastecimientoState state)
        {
            this._configReabastecimientoBL = configReabastecimientoBL;
            this._reabastecimientoBL = reabastecimientoBL;
            this._hubContext = hubContext;
            this._state = state;
        }

        // GET: api/getConfigReabastecimiento
        // Configuraciones activas con datos del producto para la tabla maestro.
        [Route("api/getConfigReabastecimiento")]
        [HttpGet]
        public async Task<JsonResult> GetConfigReabastecimiento()
        {
            try
            {
                IReadOnlyList<ConfigReabastecimientoItemDto> result =
                    await this._configReabastecimientoBL.ObtenerConfiguracionesAsync();

                JsonResult json = new JsonResult(result);
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                JsonResult json = new JsonResult(MensajeErrorServicio);
                json.StatusCode = 500;
                return json;
            }
        }

        // GET: api/getConfigReabastecimientoDetalle/{configReabastecimientoProductoId}
        // Configuración completa de un producto (maestro + ubicaciones activas).
        [Route("api/getConfigReabastecimientoDetalle/{configReabastecimientoProductoId}")]
        [HttpGet]
        public async Task<JsonResult> GetConfigReabastecimientoDetalle(long configReabastecimientoProductoId)
        {
            try
            {
                ConfigReabastecimientoDetalleDto result =
                    await this._configReabastecimientoBL.ObtenerDetalleAsync(configReabastecimientoProductoId);

                if (result == null)
                {
                    JsonResult noEncontrado = new JsonResult("La configuración no existe o ya fue inactivada");
                    noEncontrado.StatusCode = 404;
                    return noEncontrado;
                }

                JsonResult json = new JsonResult(result);
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                JsonResult json = new JsonResult(MensajeErrorServicio);
                json.StatusCode = 500;
                return json;
            }
        }

        // GET: api/getProductosSinConfigReabastecimiento
        // Productos activos sin configuración activa, elegibles para crear una nueva.
        [Route("api/getProductosSinConfigReabastecimiento")]
        [HttpGet]
        public async Task<JsonResult> GetProductosSinConfigReabastecimiento()
        {
            try
            {
                IReadOnlyList<ProductoSinConfigReabastecimientoDto> result =
                    await this._configReabastecimientoBL.ObtenerProductosSinConfigAsync();

                JsonResult json = new JsonResult(result);
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                JsonResult json = new JsonResult(MensajeErrorServicio);
                json.StatusCode = 500;
                return json;
            }
        }

        // GET: api/getUbicacionesReabastecimiento
        // Ubicaciones elegibles para asignar al proceso de reabastecimiento.
        [Route("api/getUbicacionesReabastecimiento")]
        [HttpGet]
        public async Task<JsonResult> GetUbicacionesReabastecimiento()
        {
            try
            {
                IReadOnlyList<UbicacionReabastecimientoDto> result =
                    await this._configReabastecimientoBL.ObtenerUbicacionesElegiblesAsync();

                JsonResult json = new JsonResult(result);
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                JsonResult json = new JsonResult(MensajeErrorServicio);
                json.StatusCode = 500;
                return json;
            }
        }

        // POST: api/guardarConfigReabastecimiento
        // Guardado atómico (una sola transacción) maestro + detalle.
        // configReabastecimientoProductoId = null -> creación; con valor -> edición.
        [Route("api/guardarConfigReabastecimiento")]
        [HttpPost]
        public async Task<JsonResult> GuardarConfigReabastecimiento([FromBody] GuardarConfigReabastecimientoRequestDto request)
        {
            try
            {
                if (request == null)
                {
                    JsonResult sinBody = new JsonResult(new { exitoso = false, mensaje = "El cuerpo de la petición es requerido" });
                    sinBody.StatusCode = 400;
                    return sinBody;
                }

                ConfigReabastecimientoResultDto result =
                    await this._configReabastecimientoBL.GuardarAsync(request);

                if (!result.exitoso)
                {
                    // Validación de servidor fallida (mensaje generado por el SP)
                    JsonResult invalido = new JsonResult(new { exitoso = false, mensaje = result.mensaje });
                    invalido.StatusCode = 400;
                    return invalido;
                }

                // Tras confirmar la transacción, recalcular y notificar al hub para
                // que el panel en tiempo real refleje la nueva parametrización.
                await NotificarReabastecimientoAsync();

                JsonResult json = new JsonResult(new
                {
                    exitoso = true,
                    mensaje = result.mensaje,
                    configReabastecimientoProductoId = result.configReabastecimientoProductoId
                });
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                // El logging del error ya lo realiza el DAL (LogEvent). Aquí sólo se traduce a 500.
                JsonResult json = new JsonResult(MensajeErrorServicio);
                json.StatusCode = 500;
                return json;
            }
        }

        // POST: api/inactivarConfigReabastecimiento
        // Inactivación definitiva del maestro con detalle en cascada.
        [Route("api/inactivarConfigReabastecimiento")]
        [HttpPost]
        public async Task<JsonResult> InactivarConfigReabastecimiento([FromBody] InactivarConfigReabastecimientoRequestDto request)
        {
            try
            {
                if (request == null)
                {
                    JsonResult sinBody = new JsonResult(new { exitoso = false, mensaje = "El cuerpo de la petición es requerido" });
                    sinBody.StatusCode = 400;
                    return sinBody;
                }

                ConfigReabastecimientoResultDto result =
                    await this._configReabastecimientoBL.InactivarAsync(request.configReabastecimientoProductoId, request.usuarioId);

                if (!result.exitoso)
                {
                    JsonResult invalido = new JsonResult(new { exitoso = false, mensaje = result.mensaje });
                    invalido.StatusCode = 400;
                    return invalido;
                }

                // El producto sale del proceso: recalcular y notificar al hub.
                await NotificarReabastecimientoAsync();

                JsonResult json = new JsonResult(new
                {
                    exitoso = true,
                    mensaje = result.mensaje
                });
                json.StatusCode = 200;
                return json;
            }
            catch (Exception)
            {
                JsonResult json = new JsonResult(MensajeErrorServicio);
                json.StatusCode = 500;
                return json;
            }
        }

        /// <summary>
        /// Misma lógica que api/refrescarReabastecimiento: ejecuta el cálculo,
        /// y si el hash cambió respecto al último snapshot actualiza el estado
        /// de la sala y notifica a Room_Reabastecimiento.
        /// Un fallo aquí no debe deshacer la respuesta exitosa del guardado
        /// (la transacción ya se confirmó), por eso se captura y se ignora.
        /// </summary>
        private async Task NotificarReabastecimientoAsync()
        {
            try
            {
                IReadOnlyList<ReabastecimientoItemDto> data =
                    await this._reabastecimientoBL.ObtenerReabastecimientoAsync();

                string hash = ReabastecimientoHasher.Calcular(data);

                if (!string.Equals(hash, this._state.UltimoHash, StringComparison.Ordinal))
                {
                    this._state.GuardarSnapshot(data, hash);

                    await this._hubContext.Clients
                        .Group(WmsHub.RoomReabastecimiento)
                        .SendAsync("ReabastecimientoActualizado", data);
                }
            }
            catch (Exception)
            {
                // El logging del error ya lo realiza el DAL (LogEvent).
            }
        }
    }
}
