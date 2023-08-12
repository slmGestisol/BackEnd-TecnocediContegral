using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProductoLoteBL
    {
        void AddProductoLote(ProductosLotes productoLote);
        Task<ProductosLotes> GetProductoLoteAsync(long productoLoteId);
        Task<List<ProductosLotes>> GetProductosLotesAsync();
        bool ProductoLoteExists(long productoLoteId);
    }
}