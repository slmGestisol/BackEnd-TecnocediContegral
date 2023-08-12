using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class GrupoDAL : IGrupoDAL
    {

        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public GrupoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta los grupos listas
        /// </summary>
        /// <returns></returns>
        public async Task<List<GruposListas>> GetGruposListasAsync()
        {
            return await dbcontext.GruposListas.ToListAsync();
        }

        /// <summary>
        /// Método que consulta los grupos listas  según el grupoListaId
        /// </summary>
        /// <param name="grupoListaId"></param>
        /// <returns></returns>
        ///
        public async Task<GruposListas> GetGrupoListaAsync(long grupoListaId)
        {
            var grupoLista = await dbcontext.GruposListas.FindAsync(grupoListaId);
            return grupoLista;
        }

        public async Task<List<com.ServiBarras.Infrastructure.Models.Grupos>> GetGruposAsync()
        {
            return await dbcontext.Grupos.ToListAsync();
        }

        /// <summary>
        /// Método que consulta los grupos listas  según el grupoListaId
        /// </summary>
        /// <param name="grupoListaId"></param>
        /// <returns></returns>
        ///
        public async Task<com.ServiBarras.Infrastructure.Models.Grupos> GetGrupoAsync(long grupoId)
        {
            var grupo = await dbcontext.Grupos.FindAsync(grupoId);
            return grupo;
        }
    }

}





