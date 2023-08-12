using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IClasificacionAtributoProductoBL
    {
        void AddClasificacionAtributoProducto(ClasificacionesAtributosProductos clasificacionAtributoProducto);
        bool ClasificacionAtributoProductoExists(long id);
        void DeleteClasificacionAtributoProducto(long id);
        Task<ClasificacionesAtributosProductos> GetClasificacionAtributoProductoAsync(long id);
        Task<IEnumerable<ClasificacionesAtributosProductos>> GetClasificacionAtributoProductosAsync();

    }
}