using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly IProductoBL _productoBL;

        public ProductosController(IProductoBL productoBL)
        {
            this._productoBL = productoBL;
        }
        // GET: api/Productos
        [Route("api/getproductos")]
        [HttpGet]
        public JsonResult GetProductos()
        {
            var productos = this._productoBL.GetProductosAsync();
            JsonResult json = new JsonResult(productos);
            return json;
        }

        [Route("api/getdetalleproductos")]
        [HttpGet]
        public async Task<JsonResult> GetDetalleProductos()
        {
            var productos = await this._productoBL.GetDetalleProductosAsync();
            JsonResult json = new JsonResult(productos);
            return json;
        }



        // GET api/<controller>/5
        [Route("api/GetDetalleProductoById/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetDetalleProductoById(long id)
        {
            var producto = await this._productoBL.GetDetalleProductoByIdAsync(id);
            JsonResult json = new JsonResult(producto);
            return json;
        }

        //POST api/<controller>
        [Route("api/addproducto")]
        [HttpPost]
        public async Task AddProducto([FromBody]JObject productoJson)
        {
            await this._productoBL.AddProducto(productoJson);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void UpdateProducto(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteProducto(int id)
        {
            this._productoBL.DeleteProducto(id);
        }
    }
}

