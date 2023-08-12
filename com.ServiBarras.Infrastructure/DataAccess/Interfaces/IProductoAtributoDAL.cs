using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProductoAtributoDAL
    {
        void AddProductoAtributo(ProductosAtributos productoAtributo);
        Task<ProductosAtributos> GetProductoAtributoAsync(long productoAtributoId);
        Task<List<ProductosAtributos>> GetProductosAtributosAsync();
        bool ProductoAtributoExists(long productoId, long productoPlantillaId);
    }
}