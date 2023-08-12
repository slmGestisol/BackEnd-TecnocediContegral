using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Ruteo
{
    // [Route("api/[controller]")]
    [ApiController]
    public class PreRuteoController : ControllerBase
    {
        private readonly IPreRuteoBL _preRuteoBL;
        private readonly INovedadBL _novedadBL;

        public PreRuteoController(IPreRuteoBL preRuteoBL, INovedadBL novedadBL)
        {
            this._preRuteoBL = preRuteoBL;
            this._novedadBL = novedadBL;
        }

        [Route("api/getpreruteo/{preRuteoId}")]
        [HttpGet]
        public JsonResult GetPreRuteo(long preRuteoId)
        {
            var preRuteosList = this._preRuteoBL.GetPreRuteoAsync(preRuteoId);
            JsonResult json = new JsonResult(preRuteosList);
            return json;
        }

        [Route("api/getpreruteos")]
        [HttpGet]
        public JsonResult GetPedidos()
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.GetPreRuteos();
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

        [Route("api/getpreruteoDetalle/{preRuteoId}")]
        [HttpGet]
        public JsonResult getpreruteoDetalle(long preRuteoId)
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.GetPreRuteoDetalle(preRuteoId);
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


        [Route("api/getpreruteodetallenovedad/{novedadId}")]
        [HttpGet]
        public async Task<JsonResult> getpreruteoDetalleNovedad(long novedadId)
        {
            var novedadList = await this._novedadBL.GetNovedadAsync(novedadId);
            JsonResult json = new JsonResult(novedadList);
            return json;
        }

        [Route("api/getnovedadacciones")]
        [HttpGet]
        public async Task<JsonResult> getNovedadAcciones()
        {
            var novedadAccionesList = await this._novedadBL.GetNovedadesAccionesAsync();
            JsonResult json = new JsonResult(novedadAccionesList);
            return json;
        }


        [Route("api/addpedidospreruteo")]
        [HttpPost]


        public JsonResult AddPedidosPreruteo([FromBody] JArray parametrosPedidosPreRuteo)
        {
            this._preRuteoBL.AddPedidosPreRuteo(parametrosPedidosPreRuteo);

            JsonResult json = new JsonResult(parametrosPedidosPreRuteo);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;
        }


        [Route("api/cancelpreruteo")]
        [HttpPost]
        public JsonResult CancelPreruteo([FromBody] JObject parametrosCancelPreRuteo)
        {
            this._preRuteoBL.CancelPreruteo(parametrosCancelPreRuteo);

            JsonResult json = new JsonResult(parametrosCancelPreRuteo);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }


        [Route("api/getpedidospreruteo/{preRuteoId}")]
        [HttpGet]
        public async Task<JsonResult> GetPedidosPreRuteo(long preRuteoId)
        {
            var pedidosPreruteoList = await this._preRuteoBL.GetPedidosPreRuteo(preRuteoId);

            JsonResult json = new JsonResult(pedidosPreruteoList);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }


        [Route("api/setpreruteo")]
        [HttpPost]
        public JsonResult SetPreRuteo([FromBody] JObject parametrosPreRuteo)
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.SPProcessPreRuteo(parametrosPreRuteo);
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

        [Route("api/getPreRuteoNovedades/{preRuteoId}")]
        [HttpGet]
        public JsonResult GetPreRuteoNovedades(long preRuteoId)
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.GetPreRuteoNovedades(preRuteoId);
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

        [Route("api/setPreruteoCrossDocking")]
        [HttpPost]
        public JsonResult SetPreruteoCrossDocking([FromBody] JArray parametrosPreRuteo)
        {

            DataSet result = new DataSet();
            result = this._preRuteoBL.SetPreruteoCrossDocking(parametrosPreRuteo);
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

        [Route("api/getpreruteo3/{preRuteoId}")]
        [HttpGet]
        public JsonResult GetPreRuteo2(long preRuteoId)
        {
            JsonResult json = new JsonResult("");
            return json;
        }


        [Route("api/getPedidoSecuencial")]
        [HttpGet]
        public JsonResult GetPedidoSecuencial()
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.GetPedidoSecuencial();
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

        [Route("api/getPedidoOrdenConfiguracion/{preRuteoId}")]
        [HttpGet]
        public JsonResult GetPedidoOrdenConfiguracion(long preruteoId)
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.getPedidoOrdenConfiguracion(preruteoId);
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

        [Route("api/setPedidoConfiguracion")]
        [HttpPost]


        public JsonResult setPedidoConfiguracionOrden([FromBody] JArray parametrosPedidosConfiguracionOrden)
        {
            this._preRuteoBL.setPedidoConfiguracionOrden(parametrosPedidosConfiguracionOrden);

            JsonResult json = new JsonResult(parametrosPedidosConfiguracionOrden);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;
        }

        [Route("api/addpedidosDetalleCrossDocking")]
        [HttpPost]


        public JsonResult addpedidosDetalleCrossDocking([FromBody] JArray parametrosPedidosDetalleCrossDocking)
        {
            DataSet result = new DataSet();
            result = this._preRuteoBL.addpedidosDetalleCrossDocking(parametrosPedidosDetalleCrossDocking);
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


    }
}
