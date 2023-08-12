using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICentroOperacionDAL
    {
        void AddCentroOperacion(CentrosOperaciones centroOperacion);
        bool CentroOperacionExists(long centroOperacionId);
        void DeleteCentroOperacion(long centroOperacionId);
        Task<CentrosOperaciones> GetCentroOperacionAsync(long centroOperacionId);
        Task<List<CentrosOperaciones>> GetCentrosOperacionAsync();
        Task UpdateCentroOperacionsAsync(long centroOperacionId, CentrosOperaciones centroOperacion);
    }
}