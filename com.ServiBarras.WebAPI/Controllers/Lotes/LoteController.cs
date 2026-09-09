using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Lotes
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly ILoteBL _loteBL;
        public LotesController(ILoteBL loteBL)
        {
            this._loteBL = loteBL;
        }
        

        [Route("api/getLoteByLoteCodigo/{loteCodigo}/{productoId}")]
        [HttpGet]
        public JsonResult GetLoteByLoteCodigo(string loteCodigo,long productoId)
        {
            DataSet result = new DataSet();
            result = this._loteBL.GetLoteByLoteCodigo(loteCodigo, productoId);
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
