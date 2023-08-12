using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Maquinas
{
    //[Route("api/[controller]")]
    [ApiController]
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinaBL _maquinaBL;
        public MaquinaController(IMaquinaBL maquinaBL)
        {
            this._maquinaBL = maquinaBL;
        }
        

        [Route("api/getMaquinas")]
        [HttpGet]
        public async Task<JsonResult> GetMaquinas()
        {                       
            var preRuteosList = await this._maquinaBL.GetMaquinasAsync();
            JsonResult json = new JsonResult(preRuteosList);
            return json;
        }


        [Route("api/asignarMaquinaUsuario")]
        [HttpPost]
        public JsonResult AsignarMaquinaUsuario([FromBody] JObject parametrosMaquina)
        {
            DataSet result = new DataSet();
            result = this._maquinaBL.AsignarMaquinaUsuario(parametrosMaquina);
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
