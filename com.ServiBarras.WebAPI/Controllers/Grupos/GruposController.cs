using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace com.ServiBarras.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoBL _grupoBL;

        public GruposController(IGrupoBL grupoBL)
        {
            this._grupoBL = grupoBL;
        }

        [Route("api/getgruposlistas")]
        [HttpGet]
        public async Task<JsonResult> GetGruposListas()
        {
            var grupoList = await this._grupoBL.GetGruposListasAsync();
            JsonResult json = new JsonResult(grupoList);
            return json;
        }


        [Route("api/getgrupolista/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetGrupoLista(long id)
        {
            var grupoList = await this._grupoBL.GetGrupoListaAsync(id);

            JsonResult json = new JsonResult(grupoList);
            return json;
        }


        [Route("api/getgrupos")]
        [HttpGet]
        public async Task<JsonResult> GetGrupos()
        {
            var grupoList = await this._grupoBL.GetGruposAsync();

            JsonResult json = new JsonResult(grupoList);
            return json;
        }


        [Route("api/getgrupo/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetGrupo(long id)
        {
            var grupoList = await this._grupoBL.GetGrupoAsync(id);

            JsonResult json = new JsonResult(grupoList);
            return json;
        }

    }
}
