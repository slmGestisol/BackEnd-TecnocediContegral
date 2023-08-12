using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.Servibarras.ApplicationCore.BusinessLogic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.ConfiguracionVerificacions
{   
    [ApiController]
    public class ConfiguracionVerificacionController : ControllerBase
    {
        private readonly IConfiguracionVerificacionBL _configuracionVerificacionBL;

        public ConfiguracionVerificacionController(IConfiguracionVerificacionBL configuracionVerificacionBL)
        {
            this._configuracionVerificacionBL = configuracionVerificacionBL;
        }

        // GET: api/ConfiguracionVerificacion
        [Route("api/getconfiguracionVerificacion/{tipo}")]      
        [HttpGet]
        public async Task<JsonResult> GetConfiguracionVerificacion(string tipo)
        {
            var configuracionVerificacionList = await this._configuracionVerificacionBL.GetConfiguracionVerificacion(tipo);
            JsonResult json = new JsonResult(configuracionVerificacionList);
            return json;
        }

    }
}
