using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IGrupoBL
    {
        Task<GruposListas> GetGrupoListaAsync(long grupoListaId);
        Task<List<GruposListas>> GetGruposListasAsync();
        Task<List<com.ServiBarras.Infrastructure.Models.Grupos>> GetGruposAsync();

        Task<com.ServiBarras.Infrastructure.Models.Grupos> GetGrupoAsync(long grupoId);
    }
}