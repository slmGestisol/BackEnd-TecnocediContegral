using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Contenedores
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ContenedorController : ControllerBase
    {

        private readonly IContenedorBL _contenedorBL;

        public ContenedorController(IContenedorBL contenedorBL)
        {
            this._contenedorBL = contenedorBL;
        }

        [Route("api/getcontenedoresbycontenedorcodigo")]
        [HttpPost]
        public JsonResult GetContenedoresByContenedorCodigo([FromBody] JObject parametrosContenedor)
        {

            DataSet result = new DataSet();           
            result = this._contenedorBL.GetContenedoresByContenedorCodigo(parametrosContenedor);
            
            if(result == null)
            {
                DataTable dt = new DataTable("Table");
                dt.Columns.Add(new DataColumn("resultado", typeof(int)));
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


        [Route("api/getValidarContenedorByUbicacion")]
        [HttpPost]
        public JsonResult GetValidarContenedorByUbicacion([FromBody] JObject parametrosContenedor)
        {

            DataSet result = new DataSet();
            result = this._contenedorBL.GetValidarContenedorByUbicacion(parametrosContenedor);
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


        [Route("api/getContenedoresByContenedorCodigoBarcode/{contenedorCodigo}")]
        [HttpGet]
        public JsonResult GetContenedoresByContenedorCodigoBarcode(string contenedorCodigo)
        {

            DataSet result = new DataSet();
            result = this._contenedorBL.GetContenedoresByContenedorCodigoBarcode(contenedorCodigo);
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

        [Route("api/getValidarContenedorExterno")]
        [HttpPost]
        public JsonResult GetValidarContenedorExterno([FromBody] JObject parametrosContenedor)
        {

            DataSet result = new DataSet();
            result = this._contenedorBL.GetValidarContenedorExterno(parametrosContenedor);
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
