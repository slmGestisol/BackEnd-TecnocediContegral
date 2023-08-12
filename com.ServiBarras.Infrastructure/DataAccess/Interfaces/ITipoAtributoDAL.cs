using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ITipoAtributoDAL
    {
        void AddTipoAtributo(TiposAtributos tipoAtributo);
        void DeleteTipoAtributo(long tipoAtributoId);
        Task<TiposAtributos> GetTipoAtributoAsync(long tipoAtributoId);
        Task<List<TiposAtributos>> GetTiposAtributosAsync();
        bool TipoAtributoExists(long tipoAtributoId);
        Task UpdateTiposAtributosAsync(long id, TiposAtributos atributosProducto);
    }
}