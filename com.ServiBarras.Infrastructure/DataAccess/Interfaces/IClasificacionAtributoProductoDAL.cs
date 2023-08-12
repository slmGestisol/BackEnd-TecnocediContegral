using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IClasificacionAtributoProductoDAL
    {
        void AddClasificacionAtributosProductos(ClasificacionesAtributosProductos clasificacionAtributosProductos);
        bool ClasificacionAtributosProductosExists(long id);
        void DeleteClasificacionAtributosProductos(long id);
        Task<List<ClasificacionesAtributosProductos>> GetClasificacionAtributosProductosAsync();
        Task<ClasificacionesAtributosProductos> GetClasificacionAtributosProductosAsync(long id);
        Task UpdateClasificacionAtributosProductosAsync(long id, ClasificacionesAtributosProductos clasificacionAtributosProductos);
    }
}