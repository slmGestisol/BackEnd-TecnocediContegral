using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.RFID
{
    [ApiController]
    public class RFIDController : ControllerBase
    {
        private readonly IRFIDBL _rfidBL;

        public RFIDController(IRFIDBL rfidBL)
        {
            this._rfidBL = rfidBL;
        }

        [Route("api/getPortalRFIDContenedores/{idPortal:long}/{despachoConsecutivo:long}/{inicioCaptura}")]
        [HttpGet]
        public JsonResult GetDespachobyUbicacionidpuerta(long idPortal,long despachoConsecutivo,string inicioCaptura)
        {

            DataSet result = new DataSet();
            result = this._rfidBL.GetPortalRFIDContenedores(idPortal,despachoConsecutivo, inicioCaptura);

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
