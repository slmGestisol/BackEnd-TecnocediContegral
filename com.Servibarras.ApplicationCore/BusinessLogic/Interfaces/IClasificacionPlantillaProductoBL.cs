using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IClasificacionPlantillaProductoBL
    {
        void AddClasificacionPlantillaProducto(ClasificacionesPlantillasProductos clasificacionPlantillaProducto);
        bool ClasificacionPlantillaProductoExists(long id);
        void DeleteClasificacionPlantillaProducto(long id);
        Task<IEnumerable<ClasificacionesPlantillasProductos>> GetClasificacionesPlantillasProductosAsync();
        Task<ClasificacionesPlantillasProductos> GetClasificacionPlantillaProductoAsync(long id);

    }
}