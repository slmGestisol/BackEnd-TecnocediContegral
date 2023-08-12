using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Novedades
{

    [ApiController]
    public class NovedadController : ControllerBase
    {
        private readonly INovedadBL _novedadBL;

        public NovedadController(INovedadBL novedadBL)
        {
            this._novedadBL = novedadBL;
        }

        [Route("api/getnovedadesbyprocesoId/{procesoId}")]
        [HttpGet]
        public async Task<JsonResult> GetNovedadesbyProcesoId(int procesoId)
        {
            var result = await this._novedadBL.GetNovedadesbyProcesoId(procesoId);
            if (result == null)
            {

                DataSet resultAux = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                resultAux.Tables.Add(dt);
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


        [Route("api/getnovedadesacciones")]
        [HttpGet]
        public async Task<JsonResult> GetNovedadesAccionesAsync()
        {
            var result = await this._novedadBL.GetNovedadesAccionesAsync();
            if (result == null)
            {
                DataSet resultAux = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                resultAux.Tables.Add(dt);
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

        [Route("api/getNovedadByNovedadCodigo/{novedadCodigo}")]
        [HttpGet]
        public JsonResult GetNovedadByNovedadCodigo(string novedadCodigo)
        {
            DataSet result = new DataSet();
            result = this._novedadBL.GetNovedadByNovedadCodigo(novedadCodigo);

            //_hubContext.Clients.All.SendAsync("FoodAdded", DateTime.Now);
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
