using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers.Geografia
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GeografiaController : ControllerBase
    {
        #region Ciudades

        private readonly ICiudadBL _ciudadBL;
        private readonly IEstadoBL _estadoBL;
        private readonly IPaisBL _paisBL;

        public GeografiaController(ICiudadBL ciudadBL, IEstadoBL estadoBL, IPaisBL paisBL)
        {
            this._ciudadBL = ciudadBL;
            this._estadoBL = estadoBL;
            this._paisBL = paisBL;
        }

        [Route("api/GetCiudades")]
        [HttpGet]
        public async Task<JsonResult> GetCiudades()
        {
           var ciudadesList = await this._ciudadBL.GetCiudadesAsync();
            //Ciudades ciudades = await ciudadBL.GetCiudadesAsync();
            //ciudadesList.Cast<Ciudades>().ToList();
            JsonResult json = new JsonResult(ciudadesList);
            return json;
        }

       
        [Route("api/GetCiudad/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetCiudad(long id)
        {
            var ciudad = await this._ciudadBL.GetCiudadAsync(id);
            JsonResult json = new JsonResult(ciudad);
            return json;
        }
        #endregion

        #region Estados
        [Route("api/GetEstados")]
        [HttpGet]
        public async Task<JsonResult> GetEstados()
        {
             var estados = await this._estadoBL.GetEstadosAsync();

            JsonResult json = new JsonResult(estados);
            return json;
        }

        [Route("api/GetEstado/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetEstado(long id)
        {
            var estado = await this._estadoBL.GetEstadoAsync(id);

            JsonResult json = new JsonResult(estado);
            return json;
        }
        #endregion

        #region Paises
        [Route("api/GetPaises")]
        [HttpGet]
        public async Task<JsonResult> GetPaises()
        {
             var paises = await this._paisBL.GetPaisesAsync();

            //var json = JsonConvert.SerializeObject(paises);
            JsonResult json = new JsonResult(paises);
            json.StatusCode = StatusCodes.Status200OK;
            return json;
        }

        [Route("api/GetPais/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetPais(long id)
        {
             var pais = await this._paisBL.GetPaisAsync(id);

            JsonResult json = new JsonResult(pais);
            return json;
        }
        #endregion
    }

}
