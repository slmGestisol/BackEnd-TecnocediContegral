using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICiudadDAL
    {
        void AddCiudad(Ciudades ciudad);
        bool CiudadExists(long ciudadId);
        void DeleteCiudad(long ciudadId);
        Task<Ciudades> GetCiudadAsync(long ciudadId);
        Task<List<Ciudades>> GetCiudadesAsync();
        Task UpdateCiudadAsync(long ciudadId, Ciudades ciudad);
    }
}