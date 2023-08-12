using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class TipoAtributoDAL : ITipoAtributoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public TipoAtributoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<TiposAtributos>> GetTiposAtributosAsync()
        {
            return await dbcontext.TiposAtributos.ToListAsync();
        }



        public async Task<TiposAtributos> GetTipoAtributoAsync(long tipoAtributoId)
        {
            var tipoAtributo = await dbcontext.TiposAtributos.FindAsync(tipoAtributoId);
            return tipoAtributo;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task UpdateTiposAtributosAsync(long id, TiposAtributos atributosProducto)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

        }


        public void AddTipoAtributo(TiposAtributos tipoAtributo)
        {
            dbcontext.TiposAtributos.Add(tipoAtributo);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteTipoAtributo(long tipoAtributoId)
        {
            var tipoAtributo = dbcontext.TiposAtributos.Find(tipoAtributoId);
            if (tipoAtributo == null)
            {

            }

            dbcontext.TiposAtributos.Remove(tipoAtributo);
            dbcontext.SaveChanges();


        }

        public bool TipoAtributoExists(long tipoAtributoId)
        {
            return dbcontext.TiposAtributos.Any(e => e.tipoAtributoId == tipoAtributoId);
        }
    }
}
