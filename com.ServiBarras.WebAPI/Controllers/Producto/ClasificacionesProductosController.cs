using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasificacionesProductosController : ControllerBase
    {
        private readonly IClasificacionProductoBL _clasificacionProductoBL;

        public ClasificacionesProductosController(IClasificacionProductoBL clasificacionProductoBL)
        {
            this._clasificacionProductoBL = clasificacionProductoBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetClasificacionesProductos()
        {
            var clasificacionesProductos = await this._clasificacionProductoBL.GetClasificacionProductosAsync();
            JsonResult json = new JsonResult(clasificacionesProductos);
            return json;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetClasificacionProducto(long id)
        {
            var clasificacionProducto = await this._clasificacionProductoBL.GetClasificacionProductoAsync(id);
            JsonResult json = new JsonResult(clasificacionProducto);
            return json;

        }

        // POST api/<controller>
        [HttpPost]
        public void AddClasificacionProducto([FromBody]JObject ClasificacionProductoJson)
        {
            this._clasificacionProductoBL.AddClasificacionProducto(ClasificacionProductoJson);
        }
    }
}

