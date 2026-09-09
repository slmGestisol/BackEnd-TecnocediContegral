using System;
using System.Collections.Generic;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Dashboard
{
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardBL _dashboardBL;

        public DashboardController(IDashboardBL dashboardBL)
        {
            this._dashboardBL = dashboardBL;
        }

        [Route("api/getDashboardProduccion")]
        [HttpGet]
        public JsonResult GetDashboardProduccion([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            Dictionary<string, object> result = this._dashboardBL.GetDashboardProduccion(fechaInicio, fechaFin);

            JsonResult json = new JsonResult(result);
            if (result == null)
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
