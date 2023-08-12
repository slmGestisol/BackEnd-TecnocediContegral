using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProductoClasificacionDAL : IProductoClasificacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public ProductoClasificacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<ProductosClasificaciones>> GetProductosClasificacionesAsync()
        {
            return await dbcontext.ProductosClasificaciones.ToListAsync();
        }



        public async Task<ProductosClasificaciones> GetProductoClasificacionAsync(long id)
        {
            var CriterioProductos = await dbcontext.ProductosClasificaciones.FindAsync(id);
            return CriterioProductos;
        }

        public async Task UpdateProductoClasificacionAsync(long id, ProductosClasificaciones productosClasificaciones)
        {
            if (id != productosClasificaciones.clasificacionId)
            {

            }

            dbcontext.Entry(productosClasificaciones).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!ProductoClasificacionExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddProductoClasificacion(ProductosClasificaciones productosClasificaciones)
        {
            dbcontext.ProductosClasificaciones.Add(productosClasificaciones);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteProductoClasificacion(long id)
        {
            var productosClasificaciones = dbcontext.ProductosClasificaciones.Find(id);
            if (productosClasificaciones == null)
            {

            }

            dbcontext.ProductosClasificaciones.Remove(productosClasificaciones);
            dbcontext.SaveChanges();


        }

        public bool ProductoClasificacionExists(long id)
        {
            return dbcontext.ProductosClasificaciones.Any(e => e.clasificacionId == id);
        }
    }
}
