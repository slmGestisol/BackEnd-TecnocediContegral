using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IUsuarioBL
    {
        Task<Usuarios> GetUsuarioAsync(long UsuarioId);
        Task<Usuarios> GetUsuarioLoginAsync(JObject usuarioJson);
        DataSet getPermisosByUsuarioId(long usuarioId);

    }
}