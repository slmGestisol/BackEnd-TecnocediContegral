using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class GrupoBL : IGrupoBL
    {
        private readonly IGrupoDAL _grupoDAL;

        public GrupoBL(IGrupoDAL grupoDAL)
        {
            this._grupoDAL = grupoDAL;
        }

        public async Task<List<GruposListas>> GetGruposListasAsync()
        {
            return await this._grupoDAL.GetGruposListasAsync();
        }

        /// <summary>
        /// Método que consulta los grupos listas  según el grupoListaId
        /// </summary>
        /// <param name="grupoListaId"></param>
        /// <returns></returns>
        ///
        public async Task<GruposListas> GetGrupoListaAsync(long grupoListaId)
        {
            return await this._grupoDAL.GetGrupoListaAsync(grupoListaId);
        }

        public async Task<List<com.ServiBarras.Infrastructure.Models.Grupos>> GetGruposAsync()
        {
            return await this._grupoDAL.GetGruposAsync();
        }

        /// <summary>
        /// Método que consulta los grupos listas  según el grupoListaId
        /// </summary>
        /// <param name="grupoListaId"></param>
        /// <returns></returns>
        ///
        public async Task<com.ServiBarras.Infrastructure.Models.Grupos> GetGrupoAsync(long grupoId)
        {
            return await this._grupoDAL.GetGrupoAsync(grupoId);
        }

    }
}
