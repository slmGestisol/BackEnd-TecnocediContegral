using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoLoteController : ControllerBase
    {
        private readonly IProductoLoteBL _productoLoteBL;
        private readonly IProductoAtributoBL _productoAtributoBL;

        public ProductoLoteController(IProductoLoteBL productoLoteBL, IProductoAtributoBL productoAtributoBL)
        {
            this._productoLoteBL = productoLoteBL;
            this._productoAtributoBL = productoAtributoBL;
        }

       // GET: api/ProductoLote
       [HttpGet]
        public async Task<JsonResult> GetProductosLotes()
        {
            var productosLotes = await this._productoLoteBL.GetProductosLotesAsync();
            JsonResult json = new JsonResult(productosLotes);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetProductoAtributo(long id)
        {
            var ProductoAtributo = await this._productoAtributoBL.GetProductoAtributoAsync(id);
            JsonResult json = new JsonResult(ProductoAtributo);
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
