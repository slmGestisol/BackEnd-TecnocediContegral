using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPaisDAL
    {
        void AddPais(Paises pais);
        void DeletePais(long id);
        Task<Paises> GetPaisAsync(long id);
        Task<List<Paises>> GetPaisesAsync();
        bool PaisExists(long id);
        Task UpdatePaisAsync(long id, Paises pais);
    }
}