using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentrosOperacionController : ControllerBase
    {
        private readonly ICentroOperacionBL _centroOperacionBL;

        public CentrosOperacionController(ICentroOperacionBL centroOperacionBL)
        {
            this._centroOperacionBL = centroOperacionBL;
        }

        // GET: api/CentroOperaciones
        [HttpGet]
        public async Task<JsonResult> GetCentrosOperacion()
        {
            var CentroOperaciones = await this._centroOperacionBL.GetCentrosOperacionAsync();
            JsonResult json = new JsonResult(CentroOperaciones);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetCentroOperacion(long id)
        {
            var centroOperacion = await this._centroOperacionBL.GetCentroOperacionAsync(id);
            JsonResult json = new JsonResult(centroOperacion);
            return json;
        }
     

        //// PUT api/<controller>/5
        [HttpPut("{id}")]
        public void UpdateCentroOperacion(int id, [FromBody]string value)
        {
        }

        //// DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteCentroOperacion(int id)
        {
            this._centroOperacionBL.DeleteCentroOperacion(id);
        }
    }
}
