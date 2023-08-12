using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IUsuarioDAL
    {
        Task<Usuarios> GetUsuarioAsync(long usuarioId); 
        Task<Usuarios> GetUsuarioLoginAsync(UsuarioDTO usuario);
        DataSet getPermisosByUsuarioId(long usuarioId);

    }



}