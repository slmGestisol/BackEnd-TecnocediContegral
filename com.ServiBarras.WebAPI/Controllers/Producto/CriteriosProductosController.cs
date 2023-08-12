using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriteriosCriterioProductosController : ControllerBase
    {
        private readonly ICriterioProductoBL _criterioProductoBL;

        public CriteriosCriterioProductosController(ICriterioProductoBL criterioProductoBL)
        {
            this._criterioProductoBL = criterioProductoBL;
        }
        // GET: api/CriterioProductos
        [HttpGet]
        public async Task<JsonResult> GetCriterioProductos()
        {
            var criterioProductos = await this._criterioProductoBL.GetCriteriosProductosAsync();
            JsonResult json = new JsonResult(criterioProductos);
            return json;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetCriterioProducto(long id)
        {
            var criterioProducto = await this._criterioProductoBL.GetCriterioProductoAsync(id);
            JsonResult json = new JsonResult(criterioProducto);
            return json;

        }     

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void UpdateCriterioProducto(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteCriterioProducto(int id)
        {
            this._criterioProductoBL.DeleteCriterioProducto(id);
        }
    }
}

