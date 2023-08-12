using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Configuracion
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CustodioController : ControllerBase
    {

        private readonly ICustodioBL _custodioBL;

        public CustodioController(ICustodioBL custodioBL)
        {
            this._custodioBL = custodioBL;
        }

        [Route("api/GetCustodios")]
        [HttpGet]
        public async Task<JsonResult> GetCustodios()
        {
            var custodios = await this._custodioBL.GetCustodiosAsync();
            JsonResult json = new JsonResult(custodios);
            return json;

        }

        [Route("api/GetCustodio/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetCustodio(long id)
        {
            var custodio = await this._custodioBL.GetCustodioAsync(id);

            JsonResult json = new JsonResult(custodio);
            return json;
        }

        [Route("api/AddCustodio")]
        [HttpPost]
        public async Task AddCustodio([FromBody]JObject custodioJson)
        {
            await this._custodioBL.AddCustodioAsync(custodioJson);

            //CreatedAtAction("GetTitulares", new { id = Titular.estadoId }, Titular);
        }

    }
}

