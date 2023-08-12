using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ProductoClasificacionBL : IProductoClasificacionBL
    {
        private readonly IProductoClasificacionDAL _productoClasificacionDAL;
        public ProductoClasificacionBL(IProductoClasificacionDAL productoClasificacionDAL)
        {
            this._productoClasificacionDAL = productoClasificacionDAL;
        }

        public async Task<IEnumerable<ProductosClasificaciones>> GetProductosClasificacionesAsync()
        {
            return await this._productoClasificacionDAL.GetProductosClasificacionesAsync();
        }



        public async Task<ProductosClasificaciones> GetProductoClasificacionAsync(long id)
        {
            return await this._productoClasificacionDAL.GetProductoClasificacionAsync(id);
        }



        public void AddProductoClasificacion(ProductosClasificaciones clasificacionProducto)
        {
            this._productoClasificacionDAL.AddProductoClasificacion(clasificacionProducto);

        }

        public void DeleteProductoClasificacion(long id)
        {
            this._productoClasificacionDAL.DeleteProductoClasificacion(id);

        }

        public bool ProductoClasificacionExists(long id)
        {
            return this._productoClasificacionDAL.ProductoClasificacionExists(id);
        }
    }
}
