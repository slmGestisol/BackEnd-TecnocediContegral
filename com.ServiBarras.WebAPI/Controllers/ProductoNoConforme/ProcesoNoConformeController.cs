using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.ProductoNoConforme
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductoNoConformeController : ControllerBase
    {
        private readonly IProductoNoConformeBL _productoNoConformeBL;

        public ProductoNoConformeController(IProductoNoConformeBL productoNoConformeBL)
        {
            this._productoNoConformeBL = productoNoConformeBL;
        }


        [Route("api/setGuardarNovedadesProductoNoConforme")]
        [HttpPost]
        public JsonResult SetProcesoDevolucion([FromBody] JArray parametrosContenedoresNovedad)
        {
            DataSet resultado = new DataSet();
            resultado = this._productoNoConformeBL.setGuardarNovedadesProductoNoConforme(parametrosContenedoresNovedad);
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
