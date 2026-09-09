using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{

    [ApiController]
    public class ProcesosController : ControllerBase
    {
        private const string MensajeErrorServicio = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";

        private readonly IProcesoBL _procesoBL;

        public ProcesosController(IProcesoBL procesoBL)
        {
            this._procesoBL = procesoBL;
        }

        [Route("api/GetNovedadesByNombreProceso/{nombreProceso}")]
        [HttpGet]
        public  JsonResult GetNovedadesByNombreProceso(string nombreProceso)
        {
            var result = this._procesoBL.GetNovedadesByNameProceso(nombreProceso);
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

        // GET: api/getProcesos
        // Procesos para el combo del módulo de parametrización de novedades.
        [Route("api/getProcesos")]
        [HttpGet]
        public async Task<JsonResult> GetProcesos()
        {
            try
            {
                IReadOnlyList<ProcesoComboDto> result = await this._procesoBL.ObtenerProcesosAsync();

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

    }
}
