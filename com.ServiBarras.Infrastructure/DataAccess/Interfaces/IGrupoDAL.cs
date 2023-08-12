using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IGrupoDAL
    {
        Task<GruposListas> GetGrupoListaAsync(long grupoListaId);
        Task<List<GruposListas>> GetGruposListasAsync();
        Task<com.ServiBarras.Infrastructure.Models.Grupos> GetGrupoAsync(long grupoId);
        Task<List<com.ServiBarras.Infrastructure.Models.Grupos>> GetGruposAsync();

    }
}