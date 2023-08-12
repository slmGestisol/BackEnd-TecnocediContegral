using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProductoClasificacionBL
    {
        void AddProductoClasificacion(ProductosClasificaciones clasificacionProducto);
        void DeleteProductoClasificacion(long id);
        Task<ProductosClasificaciones> GetProductoClasificacionAsync(long id);
        Task<IEnumerable<ProductosClasificaciones>> GetProductosClasificacionesAsync();
        bool ProductoClasificacionExists(long id);

    }
}