using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesEscalaresController : ControllerBase
    {
        private readonly IUnidadEscalarBL _unidadEscalarBL;

        public UnidadesEscalaresController(IUnidadEscalarBL unidadEscalarBL)
        {
            this._unidadEscalarBL = unidadEscalarBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetUnidadesEscalar()
        {
           var unidadEscalar = await this._unidadEscalarBL.GetUnidadesEscalaresAsync();
            JsonResult json = new JsonResult(unidadEscalar);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetUnidadEscalar(long id)
        {
            var unidadEscalar = await this._unidadEscalarBL.GetUnidadEscalarAsync(id);
            JsonResult json = new JsonResult(unidadEscalar);
            return json;
        }

        // POST api/<controller>

        [HttpPost]
        public void AddUnidadEscalar([FromBody]JObject unidadEscalarJson)
        {
            this._unidadEscalarBL.AddUnidadEscalar(unidadEscalarJson);
        }


        //// PUT api/<controller>/5
        [HttpPut("{id}")]
        public void UpdateUnidadEscalar(int id, [FromBody]string value)
        {
        }

        //// DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteUnidadEscalar(int id)
        {
            this._unidadEscalarBL.DeleteUnidadEscalar(id);
        }
    }
}
