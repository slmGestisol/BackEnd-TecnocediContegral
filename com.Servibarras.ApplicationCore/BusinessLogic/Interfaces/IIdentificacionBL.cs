using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IIdentificacionBL
    {
        void AddIdentificacion(Identificaciones Identificacion);
        void DeleteIdentificacion(long id);
        Task<Identificaciones> GetIdentificacionAsync(long id);
        Task<List<Identificaciones>> GetIdentificacionesAsync();
        bool IdentificacionExists(long id);

    }
}