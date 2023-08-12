using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICentroOperacionBL
    {
        void AddCentroOperacion(CentrosOperaciones centroOperacion);
        bool CentroOperacionExists(long centroOperacionId);
        void DeleteCentroOperacion(long centroOperacionId);
        Task<CentrosOperaciones> GetCentroOperacionAsync(long centroOperacionId);
        Task<IEnumerable<CentrosOperaciones>> GetCentrosOperacionAsync();

    }
}