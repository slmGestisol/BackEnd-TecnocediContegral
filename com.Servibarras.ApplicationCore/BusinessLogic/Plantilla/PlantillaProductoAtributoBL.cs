using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PlantillaProductoAtributoBL : IPlantillaProductoAtributoBL
    {
        private readonly IPlantillaProductoAtributoDAL _plantillaProductoAtributoDAL;
        public PlantillaProductoAtributoBL(IPlantillaProductoAtributoDAL plantillaProductoAtributoDAL)
        {
            this._plantillaProductoAtributoDAL = plantillaProductoAtributoDAL;
        }

        public async Task<List<PlantillasProductosAtributos>> GetPlantillasProductosAtributosAsync()
        {
            return await this._plantillaProductoAtributoDAL.GetPlantillasProductosAtributosAsync();
        }



        public async Task<PlantillasProductosAtributos> GetPlantillasProductoAtributoAsync(long plantillaProductoAtributoId)
        {
            return await this._plantillaProductoAtributoDAL.GetPlantillasProductoAtributoAsync(plantillaProductoAtributoId);
        }

        public void AddPlantillaProductoAtributo(PlantillasProductosAtributos plantillasProductoAtributo)
        {
            this._plantillaProductoAtributoDAL.AddPlantillaProductoAtributo(plantillasProductoAtributo);
        }

        public void DeletePlantillasProductoAtributo(long plantillaProductoAtributoId)
        {



        }

        public bool PlantillasProductoAtributoExists(long plantillaProductoAtributoId)
        {
            return this._plantillaProductoAtributoDAL.PlantillasProductoAtributoExists(plantillaProductoAtributoId);
        }
    }
}
