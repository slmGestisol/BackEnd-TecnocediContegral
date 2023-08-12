using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ClasificacionProductoDAL : IClasificacionProductoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public ClasificacionProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<ClasificacionesProductos>> GetClasificacionProductosAsync()
        {
            return await dbcontext.ClasificacionesProductos.ToListAsync();
        }



        public async Task<ClasificacionesProductos> GetClasificacionProductoAsync(long id)
        {
            var clasificacionProductos = await dbcontext.ClasificacionesProductos.FindAsync(id);
            return clasificacionProductos;
        }

        public async Task UpdateClasificacionProductoAsync(long id, ClasificacionesProductos clasificacionProducto)
        {
            if (id != clasificacionProducto.clasificacionProductoId)
            {

            }

            dbcontext.Entry(clasificacionProducto).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!ClasificacionProductoExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddClasificacionProducto(ClasificacionesProductos clasificacionProducto)
        {
            dbcontext.ClasificacionesProductos.Add(clasificacionProducto);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteClasificacionProducto(long id)
        {
            var clasificacionProducto = dbcontext.ClasificacionesProductos.Find(id);
            if (clasificacionProducto == null)
            {

            }

            dbcontext.ClasificacionesProductos.Remove(clasificacionProducto);
            dbcontext.SaveChanges();


        }

        public bool ClasificacionProductoExists(long id)
        {
            return dbcontext.ClasificacionesProductos.Any(e => e.clasificacionProductoId == id);
        }
    }
}
