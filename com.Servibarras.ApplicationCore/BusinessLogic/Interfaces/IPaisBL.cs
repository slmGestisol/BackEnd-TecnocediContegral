using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPaisBL
    {
        void AddPais(Paises pais);
        void DeletePais(long id);
        Task<Paises> GetPaisAsync(long id);
        Task<List<Paises>> GetPaisesAsync();
        bool PaisExists(long id);

    }
}