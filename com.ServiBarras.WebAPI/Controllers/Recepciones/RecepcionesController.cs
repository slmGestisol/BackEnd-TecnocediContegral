using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Recepciones
{
    //[Route("api/[controller]")]
    [ApiController]

    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionBL _recepcionBL;

        public RecepcionController(IRecepcionBL recepcionBL)
        {
            this._recepcionBL = recepcionBL;
        }

        //GET recepciones
        [Route("api/getRecepciones")]
        [HttpGet]
        public JsonResult getRecepciones()
        {
            var result = this._recepcionBL.getRecepciones();
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }

        //GET recepciones
        [Route("api/getRecepcionesDetalle/{recepcionId}")]
        [HttpGet]
        public JsonResult getRecepcionesDetalle(long recepcionId)
        {
            var result = this._recepcionBL.getRecepcionesDetalle(recepcionId);
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }

        //GET contenedores de recepcion por contenedor codigo
        [Route("api/getRecepcionesContenedoresByContenedorCodigo/{recepcionId}/{contenedorCodigo}")]
        [HttpGet]
        public JsonResult getRecepcionesContenedoresByContenedorCodigo(long recepcionId, string contenedorCodigo)
        {
            var result = this._recepcionBL.getRecepcionesContenedoresByContenedorCodigo(recepcionId,contenedorCodigo);
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }

        //GET recepciones
        [Route("api/getRecepcionValidacionUbicacion/{ubicacionCodigo}/{instalacionId}/{usuarioId}")]
        [HttpGet]
        public JsonResult getRecepcionValidacionUbicacion( string ubicacionCodigo, long instalacionId,long usuarioId)
        {
            var result = this._recepcionBL.getRecepcionValidacionUbicacion(ubicacionCodigo, instalacionId, usuarioId);
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }


        [Route("api/setProcesarRecepcion/")]
        [HttpPost]
        public JsonResult setProcesarRecepcion([FromBody] JObject recepcionProcesarDTO)
        {

            DataSet result = new DataSet();
            result = this._recepcionBL.setProcesarRecepcion(recepcionProcesarDTO);
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }

        [Route("api/setCerrarRecepcion/")]
        [HttpPost]
        public JsonResult setCerrarRecepcion([FromBody] JObject recepcionCerrarDTO)
        {

            DataSet result = new DataSet();
            result = this._recepcionBL.setCerrarRecepcion(recepcionCerrarDTO);
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }


    }
}
