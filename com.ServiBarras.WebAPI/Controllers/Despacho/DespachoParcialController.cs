using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Despacho
{

    [ApiController]
    public class DespachoParcialController : ControllerBase
    {
        private readonly IDespachoBL _despachoBL;
        public DespachoParcialController(IDespachoBL despachoBL)
        {
            this._despachoBL = despachoBL;
        }

        [Route("api/setdespachoparcialruteo")]
        [HttpPost]
        public JsonResult SetDespachoParcialRuteo([FromBody] JArray parametrosDespachoRuteo)
        {

            DataSet result = new DataSet();            
            result = this._despachoBL.SPDespachoPacialRuteo(parametrosDespachoRuteo);
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

        [Route("api/getpedidosdespacho")]
        [HttpPost]
        public JsonResult GetPedidosByEstiba([FromBody] JObject parametrosPedidosdespacho)
        {

            DataSet result = new DataSet();           
            result = this._despachoBL.SPPedidosDespachoParcial(parametrosPedidosdespacho);
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

        [Route("api/validardespachoparcialcargausuario/{usuarioId}")]
        [HttpGet]
        public JsonResult ValidarDespachoParcialCargaUsuario(long usuarioId)
        {

            DataSet result = new DataSet();           
            result = this._despachoBL.ValidarDespachoParcialCargaUsuario(usuarioId);
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

        [Route("api/setCancelarLineaDespachoParcial")]
        [HttpPost]
        public JsonResult SetCancelarLineaDespachoParcial([FromBody] JObject parametrosPedidosdespachoParcial)
        {

            DataSet result = new DataSet();         
            result = this._despachoBL.CancelarLineaDespachoParcial(parametrosPedidosdespachoParcial);
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

        [Route("api/setDespachoPickingPacking")]
        [HttpPost]
        public JsonResult setDespachoPickingPacking([FromBody] JObject parametrosDespachoRuteo)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.setDespachoPickingPacking(parametrosDespachoRuteo);
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
