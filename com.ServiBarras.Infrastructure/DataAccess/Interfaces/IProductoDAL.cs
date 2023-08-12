using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProductoDAL
    {
        Task AddProducto(Productos producto);
        void DeleteProducto(long productoId);
        Task<Productos> GetProductoAsync(long productoId);
        DataSet GetProductosAsync();
        bool ProductoExists(long productoId);
        Task UpdateProductoAsync(long productoId, Productos producto);

        Task<List<DetalleProducto>> GetDetalleProductosAsync();
        Task<DetalleProducto> GetDetalleProductoByIdAsync(long productoId);
    }
}