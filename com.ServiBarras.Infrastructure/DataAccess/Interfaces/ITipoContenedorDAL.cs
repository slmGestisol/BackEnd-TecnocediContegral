using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ITipoContenedorDAL
    {
        void AddTipoContenedor(TiposContenedores tipoContenedor);
        void DeleteTipoContenedor(long tipoContenedorId);
        Task<TiposContenedores> GetTipoContenedorAsync(long tipoContenedorId);
        Task<List<TiposContenedores>> GetTiposContenedoresAsync();
        bool TipoContenedorExists(long tipoContenedorId);
        Task UpdateTiposContenedoresAsync(long id, TiposContenedores tiposContenedores);
    }
}