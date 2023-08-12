using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPlantillaProductoDAL
    {
        void AddPlantillaProducto(PlantillasProductos plantillasProducto);
        void DeletePlantillasProducto(long plantillaProductoId);
        Task<PlantillasProductos> GetPlantillasProductoAsync(long plantillaProductoId);
        Task<List<PlantillasProductos>> GetPlantillasProductosAsync();
        bool PlantillasProductoExists(long plantillaProductoId);
        Task UpdatePlantillasProductosAsync(long id, PlantillasProductos plantillasProducto);
    }
}