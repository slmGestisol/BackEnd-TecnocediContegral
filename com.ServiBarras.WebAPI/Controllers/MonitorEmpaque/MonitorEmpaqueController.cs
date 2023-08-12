using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.MonitorEmpaque
{
    // [Route("api/[controller]")]
    [ApiController]
    public class MonitorEmpaqueController : ControllerBase
    {

        private readonly IOrdenEmpaqueBL _ordenEmpaqueBL;
        public MonitorEmpaqueController(IOrdenEmpaqueBL ordenEmpaqueBL)
        {
            this._ordenEmpaqueBL = ordenEmpaqueBL;
        }

        [Route("api/GetOrdenEmpaqueEstacionTrabajoUsuario")]
        [HttpPost]
        public JsonResult GetOrdenEmpaqueEstacionTrabajoUsuario([FromBody] JObject parametrosOrden)
        {
            
                DataSet result = new DataSet();
                result = this._ordenEmpaqueBL.OrdenEmpaqueEstacionTrabajoUsuario(parametrosOrden);
            
                if (result == null)
                {
                    result = new DataSet();
                    DataTable dt = new DataTable("table");
                    dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                    dt.Rows.Add(dr);
                    result.Tables.Add(dt);
                }
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

        [Route("api/getValidarOdenEmpaqueSaldoUbicacion")]
        [HttpPost]
        public JsonResult GetValidarOdenEmpaqueSaldoUbicacion([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.ValidarOdenEmpaqueSaldoUbicacion(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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



        [Route("api/setOrdenEmpaqueCambiarUbicacion")]
        [HttpPost]
        public JsonResult SetOrdenEmpaqueCambiarUbicacion([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.OrdenEmpaqueCambiarUbicacion(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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



        [Route("api/setOrdenEmpaqueEmpaqueCierreUbicacionEstiba")]
        [HttpPost]
        public JsonResult SetOrdenEmpaqueEmpaqueCierreUbicacionEstiba([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.OrdenEmpaqueCierreUbicacionEstiba(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setOrdenEmpaqueEliminarContenedor")]
        [HttpPost]
        public JsonResult SetOrdenEmpaqueEliminarContenedor([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.OrdenEmpaqueContenedorUbicacion(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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


        [Route("api/getOrdenEmpaqueContenedorbycontenedorcodigo")]
        [HttpPost]
        public JsonResult GetOrdenEmpaqueContenedorByContenedorCodigo([FromBody] JObject parametrosContenedor)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.OrdenEmpaqueContenedorByContenedorCodigo(parametrosContenedor);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setOrdenEmpaqueContenedorUbicacion")]
        [HttpPost]
        public JsonResult SetOrdenEmpaqueContenedorUbicacion([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.OrdenEmpaqueContenedorUbicacion(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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


        [Route("api/setSiesaPlanoInventario")]
        [HttpPost]
        public JsonResult SetSiesaPlanoInventario([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.SetSiesaPlanoInventario(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/getOrdenesEmpaque/")]
        [HttpGet]
        public JsonResult getOrdenesEmpaque()
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.getOrdenesEmpaque();
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setGenerarOrdenEmpaque")]
        [HttpPost]
        public JsonResult setGenerarOrdenEmpaque([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setGenerarOrdenEmpaque(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setActivarOrdenEmpaque")]
        [HttpPost]
        public JsonResult setActivarOrdenEmpaque(long ordenEmpaqueId)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setActivarOrdenEmpaque(ordenEmpaqueId); if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setCerrarOrdenEmpaque")]
        [HttpPost]
        public JsonResult setCerrarOrdenEmpaque(long ordenEmpaqueId)
        {

            string result;
            result = this._ordenEmpaqueBL.setCerrarOrdenEmpaque(ordenEmpaqueId);
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

        [Route("api/setOrdenEmpaqueFechaLote")]
        [HttpPost]
        public JsonResult setOrdenEmpaqueFechaLote([FromBody] JObject parametrosFechaLote)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setOrdenEmpaqueFechaLote(parametrosFechaLote);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/getOrdenesEmpaqueByEstacionId/{estacionId}")]
        [HttpGet]
        public JsonResult getEstacionLoteByEstacionId(long estacionId)
        {
            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.getEstacionLoteByEstacionId(estacionId);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setEstacionLoteCambiarEstado")]
        [HttpPost]
        public JsonResult setEstacionLoteCambiarEstado([FromBody] JObject parametrosCambioEstado)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setEstacionLoteCambiarEstado(parametrosCambioEstado);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setCerrarEstibaRecepcion")]
        [HttpPost]
        public JsonResult setCerrarEstibaRecepcion([FromBody] JObject parametroCerrar)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setCerrarEstibaRecepcion(parametroCerrar);
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

        [Route("api/getOrdenesExternas/{documento}")]
        [HttpGet]
        public JsonResult getOrdenesExternas(string documento)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.getOrdenesExternas(documento);
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


        [Route("api/setGenerarOrdenEmpaqueExterna")]
        [HttpPost]
        public JsonResult setGenerarOrdenEmpaqueExterna([FromBody] JObject parametrosOrden)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setGenerarOrdenEmpaqueExterna(parametrosOrden);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/getValidarLote/{documento}/{productoId}/{loteCodigo}")]
        [HttpGet]
        public JsonResult getValidarLote(string documento,long productoId, string loteCodigo)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.getValidarLoteExterno(documento, productoId, loteCodigo);
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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



        [Route("api/getCiaExternos/")]
        [HttpGet]
        public JsonResult getCiaExternos()
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.getCiaExternos();
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
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

        [Route("api/setCerrarEstibaRecepcionCalidad")]
        [HttpPost]
        public JsonResult setCerrarEstibaRecepcionCalidad([FromBody] JObject parametrosRecepcionCalidad)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setCerrarEstibaRecepcionCalidad(parametrosRecepcionCalidad);
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

        [Route("api/getTXOrdenEmpaqueById/{ordenEmpaqueId}")]
        [HttpGet]
        public JsonResult getTXOrdenEmpaqueById(long ordenEmpaqueId)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.getTXOrdenEmpaqueById(ordenEmpaqueId);
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

        [Route("api/setImprimirOrdenEmpaqueById/{txOrdenEmpaqueId}")]
        [HttpPost]
        public JsonResult setImprimirOrdenEmpaqueById(long txOrdenEmpaqueId)
        {

            DataSet result = new DataSet();
            result = this._ordenEmpaqueBL.setImprimirOrdenEmpaqueById(txOrdenEmpaqueId);
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
