using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ProductoLoteBL : IProductoLoteBL
    {

        private readonly IProductoLotesDAL _productoLoteDAL;
        public ProductoLoteBL(IProductoLotesDAL productoLoteDAL)
        {
            this._productoLoteDAL = productoLoteDAL;
        }

        public async Task<List<ProductosLotes>> GetProductosLotesAsync()
        {
            return await this._productoLoteDAL.GetProductosLotesAsync();
        }

        public async Task<ProductosLotes> GetProductoLoteAsync(long productoLoteId)
        {
            return await this._productoLoteDAL.GetProductoLoteAsync(productoLoteId);
        }

        public void AddProductoLote(ProductosLotes productoLote)
        {
            this._productoLoteDAL.AddProductoLote(productoLote);
        }

        public bool ProductoLoteExists(long productoLoteId)
        {
            return this._productoLoteDAL.ProductoLoteExists(productoLoteId);

        }




    }
}
