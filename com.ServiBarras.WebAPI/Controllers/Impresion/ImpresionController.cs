using com.Servibarras.ApplicationCore.BusinessLogic;
using com.Servibarras.ApplicationCore.BusinessLogic.Clientes;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess;
using com.ServiBarras.Infrastructure.DataAccess.Clientes;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Data;

namespace com.ServiBarras.WebAPI.Controllers.Impresion
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ImpresionController : ControllerBase
    {
        private readonly IImpresionBL _impresionBL;

        public ImpresionController(IImpresionBL impresionBL)
        {
            this._impresionBL = impresionBL;
        }

        // GET: api/getImpresoras
        [Route("api/getImpresoras")]
        [HttpGet]
        public JsonResult getImpresoras()
        {
            DataSet result = new DataSet();
            result = this._impresionBL.getImpresoras();
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
