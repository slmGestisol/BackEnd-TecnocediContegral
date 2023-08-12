using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IClasificacionProductoDAL
    {
        void AddClasificacionProducto(ClasificacionesProductos clasificacionProducto);
        bool ClasificacionProductoExists(long id);
        void DeleteClasificacionProducto(long id);
        Task<ClasificacionesProductos> GetClasificacionProductoAsync(long id);
        Task<List<ClasificacionesProductos>> GetClasificacionProductosAsync();
        Task UpdateClasificacionProductoAsync(long id, ClasificacionesProductos clasificacionProducto);
    }
}