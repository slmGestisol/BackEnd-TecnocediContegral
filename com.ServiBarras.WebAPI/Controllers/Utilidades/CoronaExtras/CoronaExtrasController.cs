using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.CoronaExtras
{
    // [Route("api/[controller]")]
    [ApiController]
    public class CoronaExtrasController : ControllerBase
    {
        private readonly ICoronaExtrasBL _coronaExtrasBL;

        public CoronaExtrasController(ICoronaExtrasBL coronaExtrasBL)
        {
            this._coronaExtrasBL = coronaExtrasBL;
        }

        [Route("api/getMercadosEstandaresByProducto/{productoId:long}")]
        [HttpGet]
        public JsonResult getMercadosEstandaresByProducto(long productoId)
        {
            DataSet result = new DataSet();
            result = this._coronaExtrasBL.getMercadosEstandaresByProducto(productoId);
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


