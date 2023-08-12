using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IUnidadEscalarDAL
    {
        void AddUnidadEscalar(UnidadesEscalares unidadEscalar);
        void DeleteUnidadEscalar(long id);
        Task<UnidadesEscalares> GetUnidadEscalarAsync(long? id);
        Task<List<UnidadesEscalares>> GetUnidadesEscalarAsync();
        bool UnidadEscalarExists(long id);
        Task UpdateUnidadEscalarsAsync(long id, UnidadesEscalares unidadEscalar);
    }
}