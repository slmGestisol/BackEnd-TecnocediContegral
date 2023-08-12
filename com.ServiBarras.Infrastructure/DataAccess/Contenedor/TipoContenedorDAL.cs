using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class TipoContenedorDAL : ITipoContenedorDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public TipoContenedorDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<TiposContenedores>> GetTiposContenedoresAsync()
        {
            return await dbcontext.TiposContenedores.ToListAsync();
        }



        public async Task<TiposContenedores> GetTipoContenedorAsync(long tipoContenedorId)
        {
            var tipoContenedor = await dbcontext.TiposContenedores.FindAsync(tipoContenedorId);
            return tipoContenedor;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task UpdateTiposContenedoresAsync(long id, TiposContenedores tiposContenedores)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

        }


        public void AddTipoContenedor(TiposContenedores tipoContenedor)
        {
            dbcontext.TiposContenedores.Add(tipoContenedor);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteTipoContenedor(long tipoContenedorId)
        {
            var tipoContenedor = dbcontext.TiposContenedores.Find(tipoContenedorId);
            if (tipoContenedor == null)
            {

            }

            dbcontext.TiposContenedores.Remove(tipoContenedor);
            dbcontext.SaveChanges();


        }

        public bool TipoContenedorExists(long tipoContenedorId)
        {
            return dbcontext.TiposContenedores.Any(e => e.tipoContenedorId == tipoContenedorId);
        }
    }
}