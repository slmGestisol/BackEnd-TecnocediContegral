using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICentroGestionBL
    {
        void AddCentroGestion(CentrosGestion centroGestion);
        bool CentroGestionExists(long centroGestionId);
        void DeleteCentroGestion(long centroGestionId);
        Task<CentrosGestion> GetCentroGestionAsync(long centroGestionId);
        Task<IEnumerable<CentrosGestion>> GetCentrosGestionAsync();

    }
}