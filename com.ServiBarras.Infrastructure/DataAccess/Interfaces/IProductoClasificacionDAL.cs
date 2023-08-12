using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProductoClasificacionDAL
    {
        void AddProductoClasificacion(ProductosClasificaciones productosClasificaciones);
        void DeleteProductoClasificacion(long id);
        Task<ProductosClasificaciones> GetProductoClasificacionAsync(long id);
        Task<List<ProductosClasificaciones>> GetProductosClasificacionesAsync();
        bool ProductoClasificacionExists(long id);
        Task UpdateProductoClasificacionAsync(long id, ProductosClasificaciones productosClasificaciones);
    }
}