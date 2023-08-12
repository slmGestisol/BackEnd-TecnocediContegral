using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Despacho
{

    [ApiController]
    public class DespachoController : ControllerBase
    {

        private readonly IDespachoBL _despachoBL;

        public DespachoController(IDespachoBL despachoBL)
        {
            this._despachoBL = despachoBL;
        }

        [Route("api/setdespachoruteo")]
        [HttpPost]
        public JsonResult SetDespachoRuteo([FromBody] JObject parametrosDespachoRuteo)
        {

            DataSet result = new DataSet();            
            result = this._despachoBL.SPDespachoRuteo(parametrosDespachoRuteo);
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

        [Route("api/getdespachodetallebyubicacioncodigo/{UbicacionCodigo}")]
        [HttpGet]
        public JsonResult GetDespachoDetalleByUbicacionCodigo(string ubicacionCodigo)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.GetDespachoDetalleByUbicacionCodigo(ubicacionCodigo);
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

        [Route("api/GetDespachoDetalleUbicacionDestino/{despachoDetalleId}")]
        [HttpGet]
        public JsonResult GetDespachoDetalleUbicacionDestino(long despachoDetalleId)
        {

            DataSet result = new DataSet();           
            result = this._despachoBL.GetDespachoDetalleUbicacionDestino(despachoDetalleId);
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


        [Route("api/GetDespachoArqueo/{ubicacionPuertaId}")]
        [HttpGet]
        public JsonResult GetDespachoArqueo(long ubicacionPuertaId)
        {
            DataSet result = new DataSet();           
            result = this._despachoBL.GetDespachoArqueo(ubicacionPuertaId);
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


        [Route("api/validardespachocargausuario/{usuarioId}")]
        [HttpGet]
        public JsonResult ValidarDespachoCargaUsuario(long usuarioId)
        {

            DataSet result = new DataSet();           
            result = this._despachoBL.ValidarDespachoCargaUsuario(usuarioId);
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

        [Route("api/cerrardespachobahiaruteo")]
        [HttpPost]
        public JsonResult CerrarDespachoBahiaRuteo([FromBody] JObject parametrosDespachoBahiaRuteo)
        {
            DataSet result = new DataSet();
            result = this._despachoBL.SPCerrarDespachoBahiaRuteo(parametrosDespachoBahiaRuteo);
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

        [Route("api/SetDespachoLibreCrearDocumento")]
        [HttpPost]
        public JsonResult DespachoLibreCrearDocumento([FromBody] JObject parametrosDespachoLibreCrearDocumento)
        {
            DataSet result = new DataSet();
            result = this._despachoBL.DespachoLibreCrearDocumento(parametrosDespachoLibreCrearDocumento);
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

        [Route("api/getDespachoLibrePuertas/{parcial}")]
        [HttpGet]
        public JsonResult getDespachoLibrePuertas(bool parcial)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.getDespachoLibrePuertas(parcial);
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

        [Route("api/getDespachoLibrePuertasDetalle/{documentoERP}/{parcial}")]
        [HttpGet]
        public JsonResult getDespachoLibrePuertasDetalle(string documentoERP,bool parcial)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.getDespachoLibrePuertasDetalle(documentoERP, parcial);
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


        [Route("api/getDespachoLibreInformacionDespacho/{documentoERP}/{productoId}")]
        [HttpGet]
        public JsonResult getDespachoLibreInformacionDespacho(string documentoERP, long productoId)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.getDespachoLibreInformacionDespacho(documentoERP, productoId);
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

        [Route("api/setDespachoLibreDocumentoProcesar")]
        [HttpPost]
        public JsonResult setDespachoLibreDocumentoProcesar([FromBody] JObject parametrosDespachoLibreProcesarDocumento)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.setDespachoLibreDocumentoProcesar(parametrosDespachoLibreProcesarDocumento);
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

        [Route("api/setDespachoLibreDocumentoCerrar")]
        [HttpPost]
        public JsonResult setDespachoLibreDocumentoCerrar([FromBody] JObject parametrosDespachoLibreCerrarDocumento)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.setDespachoLibreDocumentoCerrar(parametrosDespachoLibreCerrarDocumento);
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

        [Route("api/setDespachoLibreCambiarPuerta")]
        [HttpPost]
        public JsonResult setDespachoLibreCambiarPuerta([FromBody] JObject parametrosDespachoLibreCambiarPuerta)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.setDespachoLibreCambiarPuerta(parametrosDespachoLibreCambiarPuerta);
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

        [Route("api/getDespachoLotesPuerta/{ubicacionId}/{productoId}")]
        [HttpGet]
        public JsonResult getDespachoLotesPuerta(long ubicacionId,long productoId)
        {

            DataSet result = new DataSet();
            result = this._despachoBL.getDespachoLotesPuerta(ubicacionId, productoId);
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
