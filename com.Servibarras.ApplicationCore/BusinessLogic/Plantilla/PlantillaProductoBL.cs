using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PlantillaProductoBL : IPlantillaProductoBL
    {
        private readonly IPlantillaProductoDAL _plantillaProductoDAL;
        public PlantillaProductoBL(IPlantillaProductoDAL plantillaProductoDAL)
        {
            this._plantillaProductoDAL = plantillaProductoDAL;
        }

        public async Task<List<PlantillasProductos>> GetPlantillasProductosAsync()
        {
            return await this._plantillaProductoDAL.GetPlantillasProductosAsync();


        }



        public async Task<PlantillasProductos> GetPlantillasProductoAsync(long plantillaProductoId)
        {
            return await this._plantillaProductoDAL.GetPlantillasProductoAsync(plantillaProductoId);
        }



        public void AddPlantillaProducto(PlantillasProductos plantillasProducto)
        {
            this._plantillaProductoDAL.AddPlantillaProducto(plantillasProducto);

        }

        public void DeletePlantillasProducto(long plantillaProductoId)
        {



        }

        public bool PlantillasProductoExists(long plantillaProductoId)
        {
            return this._plantillaProductoDAL.PlantillasProductoExists(plantillaProductoId);
        }
    }
}
