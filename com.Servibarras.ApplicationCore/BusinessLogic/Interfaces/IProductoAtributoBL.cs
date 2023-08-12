using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProductoAtributoBL
    {
        void AddProductoAtributo(JObject productoAtributoJson);
        Task<ProductosAtributos> GetProductoAtributoAsync(long productoAtributoId);
        Task<List<ProductosAtributos>> GetProductosAtributosAsync();
        bool ProductoAtributoExists(long productoId, long productoPlantillaId);
    }
}