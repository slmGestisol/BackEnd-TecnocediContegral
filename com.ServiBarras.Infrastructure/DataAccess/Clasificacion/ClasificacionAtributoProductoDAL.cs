using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ClasificacionAtributoProductoDAL : IClasificacionAtributoProductoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public ClasificacionAtributoProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<List<ClasificacionesAtributosProductos>> GetClasificacionAtributosProductosAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            return null;
        }



#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ClasificacionesAtributosProductos> GetClasificacionAtributosProductosAsync(long id)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

            return null;
        }

        public async Task UpdateClasificacionAtributosProductosAsync(long id, ClasificacionesAtributosProductos clasificacionAtributosProductos)
        {
            if (id != clasificacionAtributosProductos.atributoProductoId)
            {

            }

            dbcontext.Entry(clasificacionAtributosProductos).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!ClasificacionAtributosProductosExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddClasificacionAtributosProductos(ClasificacionesAtributosProductos clasificacionAtributosProductos)
        {
            //dbcontext.ClasificacionesAtributosProductos.Add(clasificacionAtributosProductos);
            //dbcontext.SaveChangesAsync();

        }

        public void DeleteClasificacionAtributosProductos(long id)
        {
            //var clasificacionAtributosProductos = dbcontext.ClasificacionesAtributosProductos.Find(id);
            //if (clasificacionAtributosProductos == null)
            //{

            //}

            //dbcontext.ClasificacionesAtributosProductos.Remove(clasificacionAtributosProductos);
            //dbcontext.SaveChanges();


        }

        public bool ClasificacionAtributosProductosExists(long id)
        {
            return false;
            //return dbcontext.Clas.Any(e => e.atributoProductoId == id);
        }
    }
}
