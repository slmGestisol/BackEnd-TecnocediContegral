using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


namespace com.ServiBarras.WebAPI.Controllers.Clientes
{
    // [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesBL _clienteBL;

        public ClientesController(IClientesBL clientesBL)
        {
            this._clienteBL = clientesBL;
        }

        [Route("api/SetIntegrarClientes")]
        [HttpPost]
        public JsonResult SetIntegrarClientes()
        {
            var respuesta = this._clienteBL.SetIntegrarClientes();
            JsonResult json = new JsonResult(respuesta);
            return json;
        }
    }
}
