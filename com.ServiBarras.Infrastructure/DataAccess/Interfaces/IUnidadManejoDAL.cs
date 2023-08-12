using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IUnidadManejoDAL
    {
        void AddUnidadManejo(UnidadesManejo UnidadManejo);
        void DeleteUnidadManejo(long id);
        Task<List<UnidadesManejo>> GetUnidadesManejoAsync();
        Task<UnidadesManejo> GetUnidadManejoAsync(long? id);
        bool UnidadManejoExists(long id);
        Task UpdateUnidadManejosAsync(long id, UnidadesManejo UnidadManejo);
    }
}