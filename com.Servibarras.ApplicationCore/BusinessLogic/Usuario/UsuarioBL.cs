using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly IUsuarioDAL _usuarioDAL;
        public UsuarioBL(IUsuarioDAL usuarioDAL)
        {
            this._usuarioDAL = usuarioDAL;
        }

        public async Task<Usuarios> GetUsuarioAsync(long UsuarioId)
        {
            return await this._usuarioDAL.GetUsuarioAsync(UsuarioId);
        }


        public async Task<Usuarios> GetUsuarioLoginAsync(JObject usuarioJson)
        {
            var usuarioAux = JsonConvert.DeserializeObject<UsuarioDTO>(usuarioJson.ToString());
            return await this._usuarioDAL.GetUsuarioLoginAsync(usuarioAux);
        }

        public DataSet getPermisosByUsuarioId(long usuarioId)
        {
            return this._usuarioDAL.getPermisosByUsuarioId(usuarioId);
        }

        public DataSet getUsuarios()
        {
            return this._usuarioDAL.getUsuarios();
        }


        public DataSet getRoles()
        {
            return this._usuarioDAL.getRoles();
        }
        public DataSet setActualizacionCreacionUsuario(JObject parametrosUsuario)
        {
            var usuarioAux = JsonConvert.DeserializeObject<UsuarioGuardarDTO>(parametrosUsuario.ToString());

            return this._usuarioDAL.setActualizacionCreacionUsuario(usuarioAux);
        }

    }
}
