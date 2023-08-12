using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.PickingPacking
{
    // [Route("api/[controller]")]
    [ApiController]
    public class PickingPackingController : ControllerBase
    {
        private readonly IPickingPackingBL _pickingPackingBL;

        public PickingPackingController(IPickingPackingBL pickingPackingBL)
        {
            this._pickingPackingBL = pickingPackingBL;
        }

        [Route("api/getpreruteo1/{preRuteoId}")]
        [HttpGet]
        public JsonResult GetPreRuteo(long preRuteoId)
        {
            JsonResult json = new JsonResult("");
            return json;
        }

       /* [Route("api/setPickingPackingRuteo")]
        [HttpPost]
        public JsonResult SetPickingPackingRuteo([FromBody] JArray parametrosPickingPackingRuteo)
        {
            DataSet result = new DataSet();
            result = this._pickingPackingBL.SetPickingPackingRuteo(parametrosPickingPackingRuteo);
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


        }*/
    }
}
