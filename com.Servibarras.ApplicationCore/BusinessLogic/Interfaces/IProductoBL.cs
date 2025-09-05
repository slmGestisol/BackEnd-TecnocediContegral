using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProductoBL
    {
        Task AddProducto(JObject productoJson);
        void DeleteProducto(long productoId);
        Task<Productos> GetProductoAsync(long productoId);
        DataSet GetProductosAsync();
        DataSet getproductosByCodigo(string productoCodigo);
        bool ProductoExists(long productoId);

        Task<List<DetalleProducto>> GetDetalleProductosAsync();
        Task<DetalleProducto> GetDetalleProductoByIdAsync(long productoId);
    }
}