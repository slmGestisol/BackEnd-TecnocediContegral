using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IClasificacionProductoBL
    {
        void AddClasificacionProducto(JObject clasificacionProducto);
        bool ClasificacionProductoExists(long id);
        void DeleteClasificacionProducto(long id);
        Task<ClasificacionesProductos> GetClasificacionProductoAsync(long id);
        Task<IEnumerable<ClasificacionesProductos>> GetClasificacionProductosAsync();

    }
}