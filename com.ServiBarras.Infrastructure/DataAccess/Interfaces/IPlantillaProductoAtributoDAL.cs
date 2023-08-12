using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPlantillaProductoAtributoDAL
    {
        void AddPlantillaProductoAtributo(PlantillasProductosAtributos plantillasProductoAtributo);
        void DeletePlantillasProductoAtributo(long plantillaProductoAtributoId);
        Task<PlantillasProductosAtributos> GetPlantillasProductoAtributoAsync(long plantillaProductoAtributoId);
        Task<List<PlantillasProductosAtributos>> GetPlantillasProductosAtributosAsync();
        bool PlantillasProductoAtributoExists(long plantillaProductoAtributoId);
        Task UpdatePlantillasProductosAtributosAsync(long id, PlantillasProductosAtributos plantillasProductoAtributo);
    }
}