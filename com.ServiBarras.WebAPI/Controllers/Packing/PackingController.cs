using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Packing
{

    [ApiController]
    public class PackingController : ControllerBase
    {
        private readonly IPackingBL _packingBL;

        public PackingController(IPackingBL packingBL)
        {
            this._packingBL = packingBL;
        }

        [Route("api/setpackingruteo")]
        [HttpPost]
        public JsonResult SetPackingRuteo([FromBody] JObject parametrosPackingRuteo)
        {
            DataSet result = new DataSet();
            result = this._packingBL.SPPackingRuteo(parametrosPackingRuteo);
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

        [Route("api/GetpackingDetalle")]
        [HttpPost]
        public JsonResult GetPackingDetallebyPackingId([FromBody] JObject parametrosPackingRuteo)
        {
            DataSet result = new DataSet();
            result = this._packingBL.GetPackingDetallebyPackingId(parametrosPackingRuteo);
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
