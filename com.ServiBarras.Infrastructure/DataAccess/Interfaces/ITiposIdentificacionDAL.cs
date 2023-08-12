using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ITiposIdentificacionDAL
    {
        void AddTipoIdentificacion(TiposIdentificaciones tiposIdentificacion);
        void DeleteTipoIdentificacion(long id);
        Task<TiposIdentificaciones> GetTipoIdentificacionAsync(long id);
        Task<List<TiposIdentificaciones>> GetTiposIdentificacionesAsync();
        bool TipoIdentificacionExists(long id);
        Task UpdateTipoIdentificacionAsync(long id, TiposIdentificaciones tiposIdentificacion);
    }
}