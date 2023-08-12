using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ClasificacionPlantillaProductoBL : IClasificacionPlantillaProductoBL
    {
        private readonly IClasificacionPlantillaProductoDAL _clasificacionPlantillaProductoDAL;
        public ClasificacionPlantillaProductoBL(IClasificacionPlantillaProductoDAL clasificacionPlantillaProductoDAL)
        {
            this._clasificacionPlantillaProductoDAL = clasificacionPlantillaProductoDAL;
        }
        public async Task<IEnumerable<ClasificacionesPlantillasProductos>> GetClasificacionesPlantillasProductosAsync()
        {
            
            return await this._clasificacionPlantillaProductoDAL.GetClasificacionesPlantillasProductosAsync();
        }



        public async Task<ClasificacionesPlantillasProductos> GetClasificacionPlantillaProductoAsync(long id)
        {
           
            return await this._clasificacionPlantillaProductoDAL.GetClasificacionPlantillaProductoAsync(id);
        }



        public void AddClasificacionPlantillaProducto(ClasificacionesPlantillasProductos clasificacionPlantillaProducto)
        {
            this._clasificacionPlantillaProductoDAL.AddClasificacionPlantillaProducto(clasificacionPlantillaProducto);

        }

        public void DeleteClasificacionPlantillaProducto(long id)
        {
            this._clasificacionPlantillaProductoDAL.DeleteClasificacionPlantillaProducto(id);

        }

        public bool ClasificacionPlantillaProductoExists(long id)
        {
            return this._clasificacionPlantillaProductoDAL.ClasificacionPlantillaProductoExists(id);
        }
    }
}