using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProductoLotesDAL
    {
        void AddProductoLote(ProductosLotes productoLote);
        Task<ProductosLotes> GetProductoLoteAsync(long productoLoteId);
        Task<List<ProductosLotes>> GetProductosLotesAsync();
        bool ProductoLoteExists(long productoLoteId);
    }
}