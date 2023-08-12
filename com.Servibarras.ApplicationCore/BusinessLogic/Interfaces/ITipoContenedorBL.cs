using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ITipoContenedorBL
    {
        void AddTipoContenedor(TiposContenedores tipoContenedor);
        void DeleteTipoContenedor(long tipoContenedorId);
        Task<TiposContenedores> GetTipoContenedorAsync(long tipoContenedorId);
        Task<List<TiposContenedores>> GetTiposContenedoresAsync();
        bool TipoContenedorExists(long tipoContenedorId);

    }
}