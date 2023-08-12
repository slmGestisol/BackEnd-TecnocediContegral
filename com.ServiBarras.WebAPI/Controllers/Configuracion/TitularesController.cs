using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitularesController : ControllerBase
    {

        private readonly ITitularBL _titularBL;
        public TitularesController(ITitularBL titularBL)
        {
            this._titularBL = titularBL;
        }

        // GET: api/Titulares
        [HttpGet]
        public async Task<JsonResult> GetTitulares()
        {
            var titularesList = await this._titularBL.GetTitularesAsync();          
            JsonResult json = new JsonResult(titularesList);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetTitular(long id)
        {
           var titular = await this._titularBL.GetTitularAsync(id);
            JsonResult json = new JsonResult(titular);
            return json;
        }

        // POST api/<controller>
        [HttpPost]
        public void AddTitular([FromBody]JObject titularJson)
        {
            this._titularBL.AddTitular(titularJson);
        }

    }
}
