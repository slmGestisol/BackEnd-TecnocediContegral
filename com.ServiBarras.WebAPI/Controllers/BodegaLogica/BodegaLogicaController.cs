using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.BodegaLogica
{
    public class BodegaLogicaController : Controller
    {
        private readonly IBodegaLogicaBL _bodegaLogicaBL;

        public BodegaLogicaController(IBodegaLogicaBL bodegaLogicaBL)
        {
            this._bodegaLogicaBL = bodegaLogicaBL;
        }

        [Route("api/getBodegasLogicasByProcesoNombre/{procesoNombre}")]
        [HttpGet]
        public JsonResult getBodegasLogicasByProcesoNombre(string procesoNombre)
        {
            DataSet result = new DataSet();
            result = this._bodegaLogicaBL.getBodegasLogicasByProcesoNombre(procesoNombre);
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
