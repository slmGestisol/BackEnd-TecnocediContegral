using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICentroGestionDAL
    {
        void AddCentroGestion(CentrosGestion centroGestion);
        bool CentroGestionExists(long centroGestionId);
        void DeleteCentroGestion(long centroGestionId);
        Task<CentrosGestion> GetCentroGestionAsync(long centroGestionId);
        Task<List<CentrosGestion>> GetCentrosGestionAsync();
        Task UpdateCentroGestionsAsync(long centroGestionId, CentrosGestion centroGestion);
    }
}