using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Ubicacion
{
    /// <summary>
    /// Parametrización de ubicaciones contra UbicacionesListas /
    /// UbicacionesListasDetalle. Es el equivalente por ubicación del wizard
    /// de configuración por módulo, que sigue existiendo sin cambios.
    /// </summary>
    [ApiController]
    public class UbicacionesListasController : ControllerBase
    {
        private const string MensajeErrorServicio = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";

        private readonly IUbicacionListaBL _ubicacionListaBL;

        public UbicacionesListasController(IUbicacionListaBL ubicacionListaBL)
        {
            this._ubicacionListaBL = ubicacionListaBL;
        }

        // POST: api/getUbicacionesListasSegmentos
        // Valores existentes por segmento del ubicacionCodigo, ya recortados
        // por los demás filtros activos, para los ocho multi-select.
        [Route("api/getUbicacionesListasSegmentos")]
        [HttpPost]
        public async Task<JsonResult> GetUbicacionesListasSegmentos([FromBody] UbicacionListaFiltroDTO filtro)
        {
            IReadOnlyList<UbicacionListaSegmentoDTO> result =
                await this._ubicacionListaBL.ObtenerSegmentosAsync(filtro);

            JsonResult json = new JsonResult(result);

            if (result == null)
            {
                json.StatusCode = 500;
                json.Value = MensajeErrorServicio;
            }
            else
            {
                json.StatusCode = 200;
            }

            return json;
        }

        // GET: api/getUbicacionesListasCatalogo
        // Las listas disponibles para los checks de la pantalla.
        [Route("api/getUbicacionesListasCatalogo")]
        [HttpGet]
        public async Task<JsonResult> GetUbicacionesListasCatalogo()
        {
            IReadOnlyList<UbicacionListaCatalogoDTO> result =
                await this._ubicacionListaBL.ObtenerCatalogoAsync();

            JsonResult json = new JsonResult(result);

            if (result == null)
            {
                json.StatusCode = 500;
                json.Value = MensajeErrorServicio;
            }
            else
            {
                json.StatusCode = 200;
            }

            return json;
        }

        // GET: api/getUbicacionesListasTipos
        // Tipos de ubicación activos para el combo de tipo destino.
        [Route("api/getUbicacionesListasTipos")]
        [HttpGet]
        public async Task<JsonResult> GetUbicacionesListasTipos()
        {
            IReadOnlyList<TiposUbicaciones> result =
                await this._ubicacionListaBL.ObtenerTiposUbicacionAsync();

            JsonResult json = new JsonResult(result);

            if (result == null)
            {
                json.StatusCode = 500;
                json.Value = MensajeErrorServicio;
            }
            else
            {
                json.StatusCode = 200;
            }

            return json;
        }

        // POST: api/getUbicacionesListasConsulta
        // Grid de ubicaciones filtradas, con tipo, listas actuales y saldo.
        [Route("api/getUbicacionesListasConsulta")]
        [HttpPost]
        public async Task<JsonResult> GetUbicacionesListasConsulta([FromBody] UbicacionListaFiltroDTO filtro)
        {
            IReadOnlyList<UbicacionListaConsultaDTO> result =
                await this._ubicacionListaBL.ConsultarUbicacionesAsync(filtro);

            JsonResult json = new JsonResult(result);

            if (result == null)
            {
                json.StatusCode = 500;
                json.Value = MensajeErrorServicio;
            }
            else
            {
                json.StatusCode = 200;
            }

            return json;
        }

        // POST: api/setUbicacionesListasDetalle
        // Aplica el tipo de ubicación y asigna las listas marcadas.
        // Devuelve 200 con exitoso=false cuando el procedimiento rechaza el
        // cambio (por ejemplo, ubicaciones con saldo que cambiarían de tipo):
        // es un rechazo de negocio, no una falla del servicio.
        [Route("api/setUbicacionesListasDetalle")]
        [HttpPost]
        public async Task<JsonResult> SetUbicacionesListasDetalle([FromBody] UbicacionListaAsignacionDTO asignacion)
        {
            UbicacionListaRespuestaDTO result =
                await this._ubicacionListaBL.AsignarListasAsync(asignacion);

            JsonResult json = new JsonResult(result);
            json.StatusCode = 200;
            return json;
        }
    }
}
