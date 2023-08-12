using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Saldos
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SaldosController : ControllerBase
    {
        private readonly ISaldoBL _saldoBL;
        public SaldosController(ISaldoBL saldoBL)
        {
            this._saldoBL = saldoBL;
        }

        // GET: api/getSaldoDetalleByUbicacionId
        [Route("api/getSaldoDetalleByUbicacionId/{ubicacionId}/{contenedorId}")]
        [HttpGet]
        public JsonResult GetSaldoDetalleByUbicacionId(long ubicacionId, long contenedorId)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.GetSaldoDetalleByUbicacionId(ubicacionId,  contenedorId);
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

        [Route("api/setsaldoreubicacion")]
        [HttpPost]
        public JsonResult SetSaldoReubicacion([FromBody] JObject parametrosReubicacion)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.SetSaldoReubicacion(parametrosReubicacion);
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


        [Route("api/setSaldoReubicacionBarcode")]
        [HttpPost]
        public JsonResult SetSaldoReubicacionBarcode([FromBody] JObject parametrosReubicacion)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.SetSaldoReubicacionBarcode(parametrosReubicacion);
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

        [Route("api/setDescargaSaldoParcial")]
        [HttpPost]
        public JsonResult SetDescargaSaldoParcial([FromBody] JObject parametrosaldoParcial)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.SetDescargaSaldoParcial(parametrosaldoParcial);
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


        // GET: api/validarsaldocargausuario
        [Route("api/validarsaldocargausuario/{usuarioId}")]
        [HttpGet]
        public JsonResult ValidarSaldoCargaUsuario(long usuarioId)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.ValidarSaldoCargaUsuario(usuarioId);
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


        [Route("api/getUbicacionesproductosugerida")]
        [HttpPost]
        public JsonResult  GetUbicacionesProductoSugerida([FromBody] JObject parametrosReubicacion)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.GetUbicacionesProductoSugerida(parametrosReubicacion);
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

        [Route("api/setajustarsaldo")]
        [HttpPost]
        public JsonResult SetAjustarSaldo([FromBody] JArray parametrosAjusteSaldos)
        {
            string resultado = string.Empty;
            resultado = this._saldoBL.SetAjustarSaldo(parametrosAjusteSaldos);
            JsonResult json = new JsonResult(resultado);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;


        }

        [Route("api/getSaldoDetalleByContenedorCodigo")]
        [HttpPost]
        public JsonResult GetSaldoDetalleByContenedorCodigo([FromBody] JObject parametrosConsultarContenedores)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.GetSaldoDetalleByContenedorCodigo(parametrosConsultarContenedores);
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
        [Route("api/ValidarSaldoUsuarioReubicacionBarcode/{usuarioId}")]
        [HttpGet]
        public JsonResult ValidarSaldoUsuarioReubicacionBarcode(long usuarioId)
        {
            DataSet result = new DataSet();
            result = this._saldoBL.ValidarSaldoUsuarioReubicacionBarcode(usuarioId);
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



        [Route("api/setReubicacionSaldoParcial")]
        [HttpPost]
        public JsonResult setReubicacionSaldoParcial([FromBody] JArray parametrosReubicacionParcial)
        {

            DataSet result = new DataSet();
            result = this._saldoBL.setReubicacionSaldoParcial(parametrosReubicacionParcial);
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

        [Route("api/setDescomprometerUbicacion")]
        [HttpPost]
        public JsonResult setDescomprometerUbicacion([FromBody] JObject parametrosDescomprometerUbicacion)
        {

            DataSet result = new DataSet();
            result = this._saldoBL.setDescomprometerUbicacion(parametrosDescomprometerUbicacion);
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

        [Route("api/setReubicarEstiba")]
        [HttpPost]
        public JsonResult setReubicarEstiba([FromBody] JObject parametrosReubicarEstiba)
        {

            DataSet result = new DataSet();
            result = this._saldoBL.setReubicarEstiba(parametrosReubicarEstiba);
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

        [Route("api/setLimpiarEstiba")]
        [HttpPost]
        public JsonResult setLimpiarEstiba([FromBody] JObject parametrosLimpiarEstiba)
        {

            DataSet result = new DataSet();
            result = this._saldoBL.setLimpiarEstiba(parametrosLimpiarEstiba);
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

        [Route("api/setAjustarEstiba")]
        [HttpPost]
        public JsonResult setAjustarEstiba([FromBody] JObject parametrosAjustarEstiba)
        {

            DataSet result = new DataSet();
            result = this._saldoBL.setAjustarEstiba(parametrosAjustarEstiba);
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
