using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Novedades
{

    [ApiController]
    public class NovedadController : ControllerBase
    {
        private const string MensajeErrorServicio = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";

        private readonly INovedadBL _novedadBL;

        public NovedadController(INovedadBL novedadBL)
        {
            this._novedadBL = novedadBL;
        }

        [Route("api/getnovedadesbyprocesoId/{procesoId}")]
        [HttpGet]
        public async Task<JsonResult> GetNovedadesbyProcesoId(int procesoId)
        {
            var result = await this._novedadBL.GetNovedadesbyProcesoId(procesoId);
            if (result == null)
            {

                DataSet resultAux = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                resultAux.Tables.Add(dt);
            }
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


        [Route("api/getnovedadesacciones")]
        [HttpGet]
        public async Task<JsonResult> GetNovedadesAccionesAsync()
        {
            var result = await this._novedadBL.GetNovedadesAccionesAsync();
            if (result == null)
            {
                DataSet resultAux = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                resultAux.Tables.Add(dt);
            }
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

        [Route("api/getNovedadByNovedadCodigo/{novedadCodigo}")]
        [HttpGet]
        public JsonResult GetNovedadByNovedadCodigo(string novedadCodigo)
        {
            DataSet result = new DataSet();
            result = this._novedadBL.GetNovedadByNovedadCodigo(novedadCodigo);

            //_hubContext.Clients.All.SendAsync("FoodAdded", DateTime.Now);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        // GET: api/getNovedades?procesoId={procesoId}&incluirInactivas={true|false}
        // Grilla del módulo de parametrización de novedades.
        // procesoId omitido -> todos los procesos; incluirInactivas omitido -> solo activas.
        [Route("api/getNovedades")]
        [HttpGet]
        public async Task<JsonResult> GetNovedades([FromQuery] int? procesoId, [FromQuery] bool incluirInactivas = false)
        {
            try
            {
                IReadOnlyList<NovedadItemDto> result =
                    await this._novedadBL.ObtenerNovedadesAsync(procesoId, incluirInactivas);

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

        // POST: api/guardarNovedad
        // Crear (novedadId = 0 / null) o editar (novedadId > 0) una novedad.
        [Route("api/guardarNovedad")]
        [HttpPost]
        public async Task<JsonResult> GuardarNovedad([FromBody] GuardarNovedadRequestDto request)
        {
            try
            {
                if (request == null)
                {
                    JsonResult sinBody = new JsonResult(new { exitoso = false, mensaje = "El cuerpo de la petición es requerido" });
                    sinBody.StatusCode = 400;
                    return sinBody;
                }

                NovedadResultDto result = await this._novedadBL.GuardarNovedadAsync(request);

                if (!result.exitoso)
                {
                    // Validación de servidor fallida (mensaje generado por el SP)
                    JsonResult invalido = new JsonResult(new { exitoso = false, mensaje = result.mensaje });
                    invalido.StatusCode = 400;
                    return invalido;
                }

                JsonResult json = new JsonResult(new
                {
                    exitoso = true,
                    mensaje = result.mensaje,
                    novedadId = result.novedadId
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

        // POST: api/cambiarEstadoNovedad
        // Borrado lógico / reactivación (activo = false inactiva, activo = true activa).
        [Route("api/cambiarEstadoNovedad")]
        [HttpPost]
        public async Task<JsonResult> CambiarEstadoNovedad([FromBody] CambiarEstadoNovedadRequestDto request)
        {
            try
            {
                if (request == null)
                {
                    JsonResult sinBody = new JsonResult(new { exitoso = false, mensaje = "El cuerpo de la petición es requerido" });
                    sinBody.StatusCode = 400;
                    return sinBody;
                }

                NovedadResultDto result =
                    await this._novedadBL.CambiarEstadoNovedadAsync(request.novedadId, request.activo, request.usuarioId);

                if (!result.exitoso)
                {
                    JsonResult invalido = new JsonResult(new { exitoso = false, mensaje = result.mensaje });
                    invalido.StatusCode = 400;
                    return invalido;
                }

                JsonResult json = new JsonResult(new
                {
                    exitoso = true,
                    mensaje = result.mensaje,
                    novedadId = result.novedadId
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


    }
}
