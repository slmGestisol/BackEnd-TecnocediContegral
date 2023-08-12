using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProductoAtributoDAL : IProductoAtributoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public ProductoAtributoDAL()
        {

            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<ProductosAtributos>> GetProductosAtributosAsync()
        {
            return await dbcontext.ProductosAtributos.ToListAsync();
        }



        public async Task<ProductosAtributos> GetProductoAtributoAsync(long productoAtributoId)
        {
            var productoAtributo = await dbcontext.ProductosAtributos.FindAsync(productoAtributoId);
            return productoAtributo;
        }

        //public async Task UpdateProductosAtributosAsync(long id, ProductosAtributos ProductoAtributo)
        //{

        //}


        public void AddProductoAtributo(ProductosAtributos productoAtributo)
        {
            dbcontext.ProductosAtributos.Add(productoAtributo);
            dbcontext.SaveChangesAsync();

        }

        //public void DeleteProductoAtributo(long atributoProductoId)
        //{
        //    var ProductoAtributo = dbcontext.ProductosAtributos.Find(atributoProductoId);
        //    if (ProductoAtributo == null)
        //    {

        //    }

        //    dbcontext.ProductosAtributos.Remove(ProductoAtributo);
        //    dbcontext.SaveChanges();


        //}

        public bool ProductoAtributoExists(long productoId, long productoPlantillaId)
        {
            return dbcontext.ProductosAtributos.Any(e => e.productoId == productoId && e.productoPlantillaId == productoPlantillaId);
        }
    }
}
