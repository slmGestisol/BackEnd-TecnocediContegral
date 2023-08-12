using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesManejoController : ControllerBase
    {

        private readonly IUnidadManejoBL _unidadManejoBL;

        public UnidadesManejoController(IUnidadManejoBL unidadManejoBL)
        {
            this._unidadManejoBL = unidadManejoBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetUnidadesManejo()
        {           
            var unidadManejo = await this._unidadManejoBL.GetUnidadesManejoAsync();
            JsonResult json = new JsonResult(unidadManejo);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetUnidadManejo(long id)
        {
            var unidadManejo = await this._unidadManejoBL.GetUnidadManejoAsync(id);
            JsonResult json = new JsonResult(unidadManejo);
            return json;
        }

        // POST api/<controller>
        //[Route("api/AddUnidadManejo")]
        [HttpPost]
        public void AddUnidadManejo([FromBody]JObject unidadManejoJson)
        {
            this._unidadManejoBL.AddUnidadManejo(unidadManejoJson);
        }

        //// PUT api/<controller>/5
        [HttpPut("{id}")]
        public void UpdateUnidadManejo(int id, [FromBody]string value)
        {
        }

        //// DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteUnidadManejo(int id)
        {
            this._unidadManejoBL.DeleteUnidadManejo(id);
        }
    }
}
