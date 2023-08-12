using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.ProcesoDevolucion
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProcesoDevolucionController : ControllerBase
    {
        private readonly IProcesoDevolucionBL _procesoDevolucionBL;

        public ProcesoDevolucionController(IProcesoDevolucionBL procesoDevolucionBL)
        {
            this._procesoDevolucionBL = procesoDevolucionBL;
        }

        [Route("api/getValidarProcesoDevolucionCargaUsuario/{usuarioId}")]
        [HttpGet]
        public JsonResult GetValidarProcesoDevolucionCargaUsuario(long usuarioId)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.GetValidarProcesoDevolucionCargaUsuario(usuarioId);
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

        [Route("api/setProcesoDevolucion")]
        [HttpPost]
        public JsonResult SetProcesoDevolucion([FromBody] JArray parametrosSaldo)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.SPProcesoDevolucion(parametrosSaldo);
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

        [Route("api/getSaldoDetalleUbicacionContenedorCodigo")]
        [HttpPost]
        public JsonResult GetSaldoDetalleUbicacionContenedorCodigo([FromBody] JObject parametrosSaldo)
        {

            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.GetSaldoDetalleUbicacionContenedorCodigo(parametrosSaldo);
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

        [Route("api/getDevolucionDespacho")]
        [HttpGet]
        public JsonResult GetDevolucionDespacho()
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.GetDevolucionDespacho();
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
        [Route("api/SetComprometerSaldoDevolucion")]
        [HttpPost]
        public JsonResult SetComprometerSaldoDevolucion([FromBody] JObject parametrosSaldo)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.SetComprometerSaldoDevolucion(parametrosSaldo);
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


        [Route("api/SetCancelarSaldoDevolucion")]
        [HttpPost]
        public JsonResult SetCancelarSaldoDevolucion([FromBody] JObject parametrosSaldo)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.SetCancelarSaldoDevolucion(parametrosSaldo);
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


        [Route("api/getUbicacionesDespachoParcialDevolucion")]
        [HttpGet]
        public JsonResult getUbicacionesDespachoParcialDevolucion()
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.GetUbicacionesDespachoParcialDevolucion();
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


        [Route("api/getPedidoDetalleDevolucion")]
        [HttpPost]
        public JsonResult GetPedidoDetalleDevolucion([FromBody] JObject parametrosSaldo)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.GetPedidoDetalleDevolucion(parametrosSaldo);
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

        [Route("api/getContenedoresByContenedorCodigoDevolucion")]
        [HttpPost]
        public JsonResult GetContenedoresByContenedorCodigoDevolucion([FromBody] JObject parametrosContenedor)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.GetContenedoresByContenedorCodigoDevolucion(parametrosContenedor);
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

        [Route("api/setProcesarDevolucionTransaccion")]
        [HttpPost]
        public JsonResult SetProcesarDevolucionTransaccion([FromBody] JArray parametrosDevolucion)
        {
            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.SetProcesarDevolucionTransaccion(parametrosDevolucion);
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

        [Route("api/validarDespachoCargaUsuarioDevolucion/{usuarioId}")]
        [HttpGet]
        public JsonResult ValidarDespachoCargaUsuarioDevolucion(long usuarioId)
        {

            DataSet resultado = new DataSet();
            resultado = this._procesoDevolucionBL.ValidarDespachoCargaUsuarioDevolucion(usuarioId);
            if (resultado == null)
            {
                resultado = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                resultado.Tables.Add(dt);
            }
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


    }




}
