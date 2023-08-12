using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICiudadBL
    {
        void AddCiudad(Ciudades ciudad);
        void DeleteCiudad(long ciudadId);
        bool CiudadExists(long ciudadId);
        Task<IEnumerable<Ciudades>> GetCiudadesAsync();
        Task<Ciudades> GetCiudadAsync(long ciudadId);

    }
}