using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPlantillaProductoAtributoBL
    {
        void AddPlantillaProductoAtributo(PlantillasProductosAtributos plantillasProductoAtributo);
        void DeletePlantillasProductoAtributo(long plantillaProductoAtributoId);
        Task<PlantillasProductosAtributos> GetPlantillasProductoAtributoAsync(long plantillaProductoAtributoId);
        Task<List<PlantillasProductosAtributos>> GetPlantillasProductosAtributosAsync();
        bool PlantillasProductoAtributoExists(long plantillaProductoAtributoId);

    }
}