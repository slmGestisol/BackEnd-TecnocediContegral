using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProductoLotesDAL : IProductoLotesDAL
    {

        public TecnoCEDI_bdContext dbcontext;

        public ProductoLotesDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        public async Task<List<ProductosLotes>> GetProductosLotesAsync()
        {
            return await dbcontext.ProductosLotes.ToListAsync();
        }


        public async Task<ProductosLotes> GetProductoLoteAsync(long productoLoteId)
        {
            var productoLote = await dbcontext.ProductosLotes.FindAsync(productoLoteId);
            return productoLote;
        }

        public void AddProductoLote(ProductosLotes productoLote)
        {
            dbcontext.ProductosLotes.Add(productoLote);
            dbcontext.SaveChangesAsync();

        }

        public bool ProductoLoteExists(long productoLoteId)
        {
            return dbcontext.ProductosLotes.Any(e => e.productoLoteId == productoLoteId);
        }

    }
}
