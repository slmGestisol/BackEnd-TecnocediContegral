using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ITipoIdentificacionBL
    {
        void AddIdentificacion(TiposIdentificaciones tipoIdentificacion);
        void DeleteIdentificacion(long id);
        Task<TiposIdentificaciones> GetTipoIdentificacionAsync(long id);
        Task<List<TiposIdentificaciones>> GetTiposIdentificacionesAsync();
        bool IdentificacionExists(long id);

    }
}