using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.MonitorDespacho
{

    [ApiController]
    public class MonitorDespachoController : ControllerBase
    {
        private readonly IDespachoBL _despachoBL;

        public MonitorDespachoController(IDespachoBL despachoBL)
        {
            this._despachoBL = despachoBL;
        }

        [Route("api/getdespachobyubicacionidpuerta/{ubicacionIdPuerta}")]
        [HttpGet]
        public JsonResult GetDespachobyUbicacionidpuerta(long ubicacionIdPuerta)
        {
                     
            DataSet result = new DataSet();
            result = this._despachoBL.GetDespachobyUbicacionidpuerta(ubicacionIdPuerta);

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

        [Route("api/getpedidosdespachos")]
        [HttpPost]
        public JsonResult GetPedidosDespachos([FromBody] JObject parametrosPedidosDespachos)
        {
            DataSet result = new DataSet();
            result = this._despachoBL.GetPedidosDespachos(parametrosPedidosDespachos);
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


        [Route("api/getproductodespachoreciente")]
        [HttpPost]
        public JsonResult GetProductoDespachoReciente([FromBody] JObject parametrosProductoDespachos)
        {
            DataSet result = new DataSet();
            result = this._despachoBL.GetProductoDespachoReciente(parametrosProductoDespachos);
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
