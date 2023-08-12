using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ITipoAtributoBL
    {
        void AddTipoAtributo(TiposAtributos tipoAtributo);
        void DeleteTipoAtributo(long tipoAtributoId);
        Task<TiposAtributos> GetTipoAtributoAsync(long tipoAtributoId);
        Task<List<TiposAtributos>> GetTiposAtributosAsync();
        bool TipoAtributoExists(long tipoAtributoId);

    }
}