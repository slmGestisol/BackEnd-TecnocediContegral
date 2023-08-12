using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Picking
{
    //  [Route("api/[controller]")]
    [ApiController]
    public class CrossDockingController : ControllerBase
    {
        private readonly ICrossDockingBL _crossDockingBL;

        public CrossDockingController(ICrossDockingBL crossDockingBL)
        {
            this._crossDockingBL = crossDockingBL;
        }

        [Route("api/setCrossDockingRuteoDetalle")]
        [HttpPost]
        public JsonResult SetCrossDockingRuteoDetalle([FromBody] JObject parametrosCrossDocking)
        {

            DataSet result = new DataSet();
            result = this._crossDockingBL.SetCrossDockingRuteoDetalle(parametrosCrossDocking);
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


        [Route("api/getFiltroBahiasProductosCrossDocking")]
        [HttpPost]
        public JsonResult GetFiltroBahiasProductosCrossDocking([FromBody] JObject parametrosCrossDocking)
        {

            DataSet result = new DataSet();
            result = this._crossDockingBL.GetFiltroBahiasProductosCrossDocking(parametrosCrossDocking);
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

        [Route("api/getPickingCrossDocking/")]
        [HttpGet]
        public JsonResult getPickingCrossDocking()
        {
            DataSet result = new DataSet();
            result = this._crossDockingBL.getPickingCrossDocking();

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

        [Route("api/getCodigoUbicacionByUsuarioIdCrossDocking")]
        [HttpPost]
        public JsonResult GetCodigoUbicacionByUsuarioIdCrossDocking([FromBody] JObject parametrosCrossDocking)
        {

            DataSet result = new DataSet();
            result = this._crossDockingBL.GetCodigoUbicacionByUsuarioIdCrossDocking(parametrosCrossDocking);
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

        [Route("api/getSaldoDetalleRuteoCrossDocking")]
        [HttpPost]
        public JsonResult GetSaldoDetalleRuteoCrossDocking([FromBody] JObject parametrosCrossDocking)
        {

            DataSet result = new DataSet();
            result = this._crossDockingBL.GetSaldoDetalleRuteoCrossDocking(parametrosCrossDocking);
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
