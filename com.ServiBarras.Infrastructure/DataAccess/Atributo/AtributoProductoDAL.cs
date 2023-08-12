using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class AtributoProductoDAL : IAtributoProductoDAL
    {

        public TecnoCEDI_bdContext dbcontext;


        public AtributoProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<AtributosProductos>> GetAtributosProductosAsync()
        {
            return await dbcontext.AtributosProductos.ToListAsync();
        }



        public async Task<AtributosProductos> GetAtributosProductoAsync(long atributoProductoId)
        {
            var atributosProducto = await dbcontext.AtributosProductos.FindAsync(atributoProductoId);
            return atributosProducto;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task UpdateAtributosProductosAsync(long id, AtributosProductos atributosProducto)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

        }


        public void AddAtributoProducto(AtributosProductos atributosProducto)
        {
            dbcontext.AtributosProductos.Add(atributosProducto);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteAtributosProducto(long atributoProductoId)
        {
            var atributosProducto = dbcontext.AtributosProductos.Find(atributoProductoId);
            if (atributosProducto == null)
            {

            }

            dbcontext.AtributosProductos.Remove(atributosProducto);
            dbcontext.SaveChanges();


        }

        public bool AtributosProductoExists(long atributoProductoId)
        {
            return dbcontext.AtributosProductos.Any(e => e.atributoProductoId == atributoProductoId);
        }
    }
}
