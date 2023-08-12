using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IIdentificacionDAL
    {
        void AddIdentificacion(Identificaciones identificacion);
        void DeleteIdentificacion(long id);
        Task<Identificaciones> GetIdentificacionAsync(long id);
        Task<List<Identificaciones>> GetIdentificacionesAsync();
        bool IdentificacionExists(long id);
        Task UpdateIdentificacionAsync(long id, Identificaciones identificacion);
    }
}