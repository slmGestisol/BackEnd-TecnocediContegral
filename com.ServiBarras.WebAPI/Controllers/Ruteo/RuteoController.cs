using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Ruteo
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RuteoController : ControllerBase
    {
        private readonly IRuteoBL _ruteoBL;
        public RuteoController(IRuteoBL ruteoBL)
        {
            this._ruteoBL = ruteoBL;
        }

        // GET: api/getruteos
        [Route("api/getruteos")]
        [HttpGet]
        public async Task<JsonResult> GetRuteos()
        {
            var ruteosList = await this._ruteoBL.GetRuteosAsync();
            JsonResult json = new JsonResult(ruteosList);
            return json;
        }

        // GET: api/getruteosByInstalacionId/2
        [Route("api/getruteosByInstalacionId/{instalacionId}")]
        [HttpGet]
        public JsonResult GetRuteosByInstalacionId(long instalacionId)
        {
            var ruteosList =  this._ruteoBL.GetRuteosByInstalacionIdAsync(instalacionId);
            JsonResult json = new JsonResult(ruteosList);
            return json;
        }

        // GET: api/getruteo/5
        [Route("api/getruteo/{ruteoId}")]
        [HttpGet]
        public async Task<JsonResult> GetRuteo(long ruteoId)
        {
            var ruteosList = await this._ruteoBL.GetRuteosAsync(ruteoId);
            JsonResult json = new JsonResult(ruteosList);
            return json;
        }


        [Route("api/getruteoDetalle")]
        [HttpPost]
        public JsonResult getRuteoDetalle([FromBody] JObject parametrosRuteo)
        {
            var ruteosList = this._ruteoBL.GetRuteoDetalle(parametrosRuteo);
            JsonResult json = new JsonResult(ruteosList);
            return json;
        }


        [Route("api/getruteoDetallebyFilters")]
        [HttpPost]
        public JsonResult GetRuteoDetallebyFilters([FromBody] JObject parametrosRuteo)
        {
            var ruteosList = this._ruteoBL.GetRuteoDetalleFilters(parametrosRuteo);
            JsonResult json = new JsonResult(ruteosList);
            return json;
        }

        [Route("api/getruteoDetalleItem/{ruteoDetalleId}")]
        [HttpGet]
        public async Task<JsonResult> getRuteoDetalleItem(long ruteoDetalleId)
        {
            var ruteosDetalleList = await this._ruteoBL.GetRuteosDetalleItemAsync(ruteoDetalleId);
            JsonResult json = new JsonResult(ruteosDetalleList);
            return json;
        }

        [Route("api/GetRuteosPedidosBahiasbyRuteoId/{ruteoId}")]
        [HttpGet]
        public JsonResult GetRuteosPedidosBahiasbyRuteoId(long ruteoId)
        {
            var ruteospedidosist = this._ruteoBL.GetRuteosPedidosBahiasbyRuteoId(ruteoId);
            JsonResult json = new JsonResult(ruteospedidosist);
            return json;
        }


        [Route("api/GetRuteosProductosbyRuteoId/{ruteoId}")]
        [HttpGet]
        public JsonResult GetRuteosProductosbyRuteoId(long ruteoId)
        {
            var ruteospedidosist = this._ruteoBL.GetRuteosPedidosProductosbyRuteoId(ruteoId);
            JsonResult json = new JsonResult(ruteospedidosist);
            return json;
        }


        // POST: api/SetRuteo
        [Route("api/Setruteo")]
        [HttpPost]
        public JsonResult SetRuteo([FromBody] JObject parametrosRuteo)
        {
            DataSet result = new DataSet();
            result = this._ruteoBL.SP_Add_Ruteo(parametrosRuteo);
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


        [Route("api/addnovedadruteo")]
        [HttpPost]
        public JsonResult AddNovedadRuteo([FromBody] JObject parametrosRuteo)
        {
            DataSet result = new DataSet();           
            result = this._ruteoBL.SP_Add_NovedadRuteo(parametrosRuteo);
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


        [Route("api/GetAsignacionBahiasRuteoId/{ruteoId}")]
        [HttpGet]
        public JsonResult GetAsignacionBahiasRuteoId(int ruteoId)
        {
            DataSet result = new DataSet();          
            var asignacionList = this._ruteoBL.GetAsignacionBahiasRuteoId(ruteoId);

            JsonResult json = new JsonResult(asignacionList);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;
        }



        [Route("api/getFiltroBahiasProductosRuteo")]
        [HttpPost]
        public JsonResult GetFiltroBahiasProductosRuteo([FromBody] JObject parametrosRuteo)
        {
            DataSet result = new DataSet();
            result = this._ruteoBL.GetFiltroBahiasProductosRuteo(parametrosRuteo);
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


        [Route("api/getRuteoPedidosInfo/{ruteoId}")]
        [HttpGet]
        public JsonResult GetRuteoPedidosInfo(long ruteoId)
        {
            var ruteosList = this._ruteoBL.GetRuteoPedidosInfo(ruteoId);
            JsonResult json = new JsonResult(ruteosList);
            return json;
        }

    }
}
