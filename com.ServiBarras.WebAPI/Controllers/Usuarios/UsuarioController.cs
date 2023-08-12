using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.Servibarras.ApplicationCore.BusinessLogic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Controllers.Usuarios
{   
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBL _usuarioBL;

        public UsuarioController(IUsuarioBL usuarioBL)
        {
            this._usuarioBL = usuarioBL;
        }
        // GET: api/Usuario
        [Route("api/getusuario/{usuarioId}")]      
        [HttpGet]               
        public async Task<JsonResult> GetUsuario(long usuarioId)
        {
            var usuarioList = await this._usuarioBL.GetUsuarioAsync(usuarioId);
            JsonResult json = new JsonResult(usuarioList);
            return json;
        }
       
        [Route("api/getUsuarioLoginAsync")]       
        [HttpPost]      
        public async Task<JsonResult> GetUsuarioLoginAsync([FromBody] JObject parametrosUsuario)
        {
           
            var usuarioList = await this._usuarioBL.GetUsuarioLoginAsync(parametrosUsuario);           
                JsonResult json = new JsonResult(usuarioList);
                if (json.Value == null)
                {
                    json.StatusCode = 500;
                    json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                }
                else
                    json.StatusCode = 200;

                return json;
            }

        // GET: api/getPermisosByUsuarioId
        [Route("api/getPermisosByUsuarioId/{usuarioId}")]
        [HttpGet]
        public JsonResult getPermisosByUsuarioId(long usuarioId)
        {
            var result = this._usuarioBL.getPermisosByUsuarioId(usuarioId);
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





    }
}
