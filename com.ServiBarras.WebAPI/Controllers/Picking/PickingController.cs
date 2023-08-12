using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Picking
{
    // [Route("api/[controller]")]
    [ApiController]
    public class PickingController : ControllerBase
    {
        private readonly IPickingBL _pickingBL;

        public PickingController(IPickingBL pickingBL)
        {
            this._pickingBL = pickingBL;
        }

        [Route("api/setpickingruteo")]
        [HttpPost]
        public JsonResult SetPickingRuteo([FromBody] JObject parametrosPickingRuteo)
        {
            DataSet result = new DataSet();
            result = this._pickingBL.SPPickingRuteo(parametrosPickingRuteo);
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
        
        [Route("api/setPickingPackingRuteo")]
        [HttpPost]
        public JsonResult SetPickingPackingRuteo([FromBody] JArray parametrosPickingPackingRuteo)
        {
            DataSet result = new DataSet();
            result = this._pickingBL.SetPickingPackingRuteo(parametrosPickingPackingRuteo);
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

        [Route("api/getPickingPackingByRuteo/{ruteoId}/{ruteoDetalleId}")]
        [HttpGet]
        public JsonResult getPickingPackingByRuteo(long ruteoId,long ruteoDetalleId)
        {
            DataSet result = new DataSet();
            result = this._pickingBL.getPickingPackingByRuteo(ruteoId, ruteoDetalleId);
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

        [Route("api/SetPickingPackingRuteoNovedad")]
        [HttpPost]
        public JsonResult SetPickingPackingRuteoNovedad([FromBody] JArray parametrosPickingPackingRuteo)
        {
            DataSet result = new DataSet();
            result = this._pickingBL.SetPickingPackingRuteoNovedad(parametrosPickingPackingRuteo);
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
