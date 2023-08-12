using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IClasificacionPlantillaProductoDAL
    {
        void AddClasificacionPlantillaProducto(ClasificacionesPlantillasProductos clasificacionesPlantillasProductos);
        bool ClasificacionPlantillaProductoExists(long id);
        void DeleteClasificacionPlantillaProducto(long id);
        Task<List<ClasificacionesPlantillasProductos>> GetClasificacionesPlantillasProductosAsync();
        Task<ClasificacionesPlantillasProductos> GetClasificacionPlantillaProductoAsync(long id);
        Task UpdateClasificacionPlantillaProductoAsync(long id, ClasificacionesPlantillasProductos clasificacionesPlantillasProductos);
    }
}