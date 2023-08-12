using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{

    [ApiController]
    public class ProcesosController : ControllerBase
    {

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

    }
}
