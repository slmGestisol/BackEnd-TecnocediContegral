using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Ubicacion
{
    // [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacionBL _ubicacionBL;

        public UbicacionesController(IUbicacionBL ubicacionBL)
        {
            this._ubicacionBL = ubicacionBL;
        }

        [Route("api/getubicaciones")]
        [HttpGet]
        public async Task<JsonResult> GetUbicaciones()
        {
            var ubicacionesList = await this._ubicacionBL.GetUbicacionesAsync();
            JsonResult json = new JsonResult(ubicacionesList);
            return json;
        }

        [Route("api/getubicaciones/{id}")]
        [HttpGet]
        public async Task<JsonResult> GetUbicacion(long id)
        {
            var ubicacionesList = await this._ubicacionBL.GetUbicacionAsync(id);
            JsonResult json = new JsonResult(ubicacionesList);
            return json;
        }


        [Route("api/getubicacionesbytipoubicacionid/")]
        [HttpPost]
        public async Task<JsonResult> GetUbicacionesByTipoUbicacionId([FromBody] JObject parametrosUbicacion)
        {
            var ubicacionesList = await this._ubicacionBL.GetUbicacionesByTipoUbicacionAsync(parametrosUbicacion);
            JsonResult json = new JsonResult(ubicacionesList);
            return json;
        }


        [Route("api/GetCodigoUbicacionByUsuarioId/{usuarioId}")]
        [HttpGet]
        public JsonResult GetCodigoUbicacionByUsuarioId(long usuarioId)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetCodigoUbicacionByUsuarioId(usuarioId);
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


        [Route("api/GetCodigoReubicacionByUsuarioId/{usuarioId}")]
        [HttpGet]
        public JsonResult GetCodigoReubicacionByUsuarioId(long usuarioId)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetCodigoReubicacionByUsuarioId(usuarioId);
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


        [Route("api/GetCodigoUbicacionPuertaByBahiaId/{bahiaId}")]
        [HttpGet]
        public JsonResult GetCodigoUbicacionPuertaByBahiaId(long bahiaId)
        {
            string result = "";
            result = this._ubicacionBL.GetCodigoUbicacionPuertaByBahiaId(bahiaId);
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



        [Route("api/getCodigoUbicacionByBahiaPadreId/")]
        [HttpPost]
        public JsonResult GetCodigoUbicacionByBahiaPadreId([FromBody] JObject parametrosUbicacion)
        {
            string result = "";
            result = this._ubicacionBL.GetCodigoUbicacionByBahiaPadreId(parametrosUbicacion);
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


        [Route("api/getruteoDetalleUbicacionCapturada/")]
        [HttpPost]
        public JsonResult getruteoDetalleUbicacionCapturada([FromBody] JObject parametrosUbicacion)
        {
            var ubicacionesList = this._ubicacionBL.getruteoDetalleUbicacionCapturada(parametrosUbicacion);
            JsonResult json = new JsonResult(ubicacionesList);
            return json;
        }
        
        [Route("api/getpuertasubicaciones/{instalacionId}")]
        [HttpGet]
        public JsonResult GetPuertasUbicaciones(long instalacionId)
        {
            DataSet result =new DataSet();
            result = this._ubicacionBL.getPuertasUbicaciones(instalacionId);
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

        [Route("api/getContenedoresByUbicacionCodigo/{ubicacionCodigo}")]
        [HttpGet]
        public JsonResult GetContenedoresByUbicacionesCodigo(string ubicacionCodigo)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetContenedoresByUbicacionesCodigo(ubicacionCodigo);
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

        [Route("api/getUbicacionByUbicacionCodigo/{ubicacionCodigo}")]
        [HttpGet]
        public JsonResult GetUbicacionByUbicacionCodigo(string ubicacionCodigo)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetUbicacionByUbicacionCodigo(ubicacionCodigo);
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

        [Route("api/getDespachoParcialUbicaciones/{instalacionId}")]
        [HttpGet]
        public JsonResult GetDespachoParcialUbicaciones(long instalacionId)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetDespachoParcialUbicaciones(instalacionId);
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


        [Route("api/getBahiasDisponiblesByBahiaPadre/")]
        [HttpPost]
        public JsonResult GetBahiasDisponiblesByBahiaPadre([FromBody] JObject parametrosUbicacion)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetBahiasDisponiblesByBahiaPadre(parametrosUbicacion);
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


        [Route("api/getUbicacionByUbicacionCodigoBarcode/{ubicacionCodigo}")]
        [HttpGet]
        public JsonResult GetUbicacionByUbicacionCodigoBarcode(string ubicacionCodigo)
        {
            DataSet result = new DataSet();
            result = this._ubicacionBL.GetUbicacionByUbicacionCodigoBarcode(ubicacionCodigo);
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


