using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PlantillaProductoAtributoDAL : IPlantillaProductoAtributoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public PlantillaProductoAtributoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<PlantillasProductosAtributos>> GetPlantillasProductosAtributosAsync()
        {
            return await dbcontext.PlantillasProductosAtributos.ToListAsync();
        }



        public async Task<PlantillasProductosAtributos> GetPlantillasProductoAtributoAsync(long plantillaProductoAtributoId)
        {
            var plantillasProductoAtributo = await dbcontext.PlantillasProductosAtributos.FindAsync(plantillaProductoAtributoId);
            return plantillasProductoAtributo;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task UpdatePlantillasProductosAtributosAsync(long id, PlantillasProductosAtributos plantillasProductoAtributo)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

        }


        public void AddPlantillaProductoAtributo(PlantillasProductosAtributos plantillasProductoAtributo)
        {
            dbcontext.PlantillasProductosAtributos.Add(plantillasProductoAtributo);
            dbcontext.SaveChangesAsync();

        }

        public void DeletePlantillasProductoAtributo(long plantillaProductoAtributoId)
        {
            var plantillasProductoAtributo = dbcontext.PlantillasProductosAtributos.Find(plantillaProductoAtributoId);
            if (plantillasProductoAtributo == null)
            {

            }

            dbcontext.PlantillasProductosAtributos.Remove(plantillasProductoAtributo);
            dbcontext.SaveChanges();


        }

        public bool PlantillasProductoAtributoExists(long plantillaProductoAtributoId)
        {
            return dbcontext.PlantillasProductosAtributos.Any(e => e.plantillaProductoAtributoId == plantillaProductoAtributoId);
        }
    }
}
