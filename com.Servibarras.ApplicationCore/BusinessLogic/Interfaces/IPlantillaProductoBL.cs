using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPlantillaProductoBL
    {
        void AddPlantillaProducto(PlantillasProductos plantillasProducto);
        void DeletePlantillasProducto(long plantillaProductoId);
        Task<PlantillasProductos> GetPlantillasProductoAsync(long plantillaProductoId);
        Task<List<PlantillasProductos>> GetPlantillasProductosAsync();
        bool PlantillasProductoExists(long plantillaProductoId);

    }
}