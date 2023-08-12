using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Estaciones
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EstacionesController : ControllerBase
    {
        private readonly IEstacionBL _estacionBL;

        public EstacionesController(IEstacionBL estacionBL)
        {
            this._estacionBL = estacionBL;
        }

        [Route("api/getEstaciones/{tipoEstacionCodigo}")]
        [HttpGet]
        public JsonResult GetEstaciones(string  tipoEstacionCodigo)
        {
            DataSet result = new DataSet();           
            result = this._estacionBL.GetEstaciones(tipoEstacionCodigo);
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

        [Route("api/getUbicacionesByEstacionId/{estacionId}")]
        [HttpGet]
        public JsonResult GetUbicacionesByEstacionId(long estacionId)
        {
            DataSet result = new DataSet();        
            result = this._estacionBL.GetUbicacionesByEstacionId(estacionId);
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
