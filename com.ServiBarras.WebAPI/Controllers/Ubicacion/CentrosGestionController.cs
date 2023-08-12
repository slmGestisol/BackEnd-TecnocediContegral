using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentrosGestionController : ControllerBase
    {
        private readonly ICentroGestionBL _centroGestionBL;
        public CentrosGestionController(ICentroGestionBL centroGestionBL)
        {
            this._centroGestionBL = centroGestionBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetCentrosGestion()
        {
            var CentroGestiones = await this._centroGestionBL.GetCentrosGestionAsync();
            JsonResult json = new JsonResult(CentroGestiones);
            return json;
        }

        //// GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetCentroGestion(long id)
        {
            var centroGestion = await this._centroGestionBL.GetCentroGestionAsync(id);
            JsonResult json = new JsonResult(centroGestion);
            return json;
        }

      
        //// PUT api/<controller>/5
        [HttpPut("{id}")]
        public void UpdateCentroGestion(int id, [FromBody]string value)
        {
        }

        //// DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteCentroGestion(int id)
        {
            this._centroGestionBL.DeleteCentroGestion(id);
        }
    }
}
