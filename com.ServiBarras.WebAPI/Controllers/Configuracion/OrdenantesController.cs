using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenantesController : ControllerBase
    {

        private readonly IOrdenanteBL _ordenanteBL;

        public OrdenantesController(IOrdenanteBL ordenanteBL)
        {
            this._ordenanteBL = ordenanteBL;
        }
        // GET: api/Ordenantes

        [HttpGet]
        public async Task<JsonResult> GetOrdenantes()
        {           
            var ordenantes = await this._ordenanteBL.GetOrdenantesAsync();
            JsonResult json = new JsonResult(ordenantes);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetOrdenante(long id)
        {
            var ordenante = await this._ordenanteBL.GetOrdenanteAsync(id);
            JsonResult json = new JsonResult(ordenante);
            return json;
        }

        // POST api/<controller>
        [HttpPost]
        public void AddOrdenante([FromBody]JObject ordenanteJson)
        {
            this._ordenanteBL.AddOrdenante(ordenanteJson);
        }

    }
}
