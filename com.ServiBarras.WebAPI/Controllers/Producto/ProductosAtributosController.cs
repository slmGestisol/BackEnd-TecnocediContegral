using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosAtributosController : ControllerBase
    {
        private readonly IProductoAtributoBL _productoAtributoBL;

        public ProductosAtributosController(IProductoAtributoBL productoAtributoBL)
        {
            this._productoAtributoBL = productoAtributoBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetProductosAtributos()
        {
            var productoAtributos = await this._productoAtributoBL.GetProductosAtributosAsync();
            JsonResult json = new JsonResult(productoAtributos);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetProductoAtributo(long id)
        {
            var productoAtributo = await this._productoAtributoBL.GetProductoAtributoAsync(id);
            JsonResult json = new JsonResult(productoAtributo);
            return json;
        }

        // POST api/<controller>
        [HttpPost]
        public void AddProductoAtributo([FromBody]JObject productoAtributoJson)
        {
            this._productoAtributoBL.AddProductoAtributo(productoAtributoJson);
        }    
    }
}
