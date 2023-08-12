using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PlantillaProductoDAL : IPlantillaProductoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public PlantillaProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<PlantillasProductos>> GetPlantillasProductosAsync()
        {
            return await dbcontext.PlantillasProductos.ToListAsync();
        }



        public async Task<PlantillasProductos> GetPlantillasProductoAsync(long plantillaProductoId)
        {
            var plantillasProducto = await dbcontext.PlantillasProductos.FindAsync(plantillaProductoId);
            return plantillasProducto;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task UpdatePlantillasProductosAsync(long id, PlantillasProductos plantillasProducto)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {

        }


        public void AddPlantillaProducto(PlantillasProductos plantillasProducto)
        {
            dbcontext.PlantillasProductos.Add(plantillasProducto);
            dbcontext.SaveChangesAsync();

        }

        public void DeletePlantillasProducto(long plantillaProductoId)
        {
            var plantillasProducto = dbcontext.PlantillasProductos.Find(plantillaProductoId);
            if (plantillasProducto == null)
            {

            }

            dbcontext.PlantillasProductos.Remove(plantillasProducto);
            dbcontext.SaveChanges();


        }

        public bool PlantillasProductoExists(long plantillaProductoId)
        {
            return dbcontext.PlantillasProductos.Any(e => e.plantillaProductoId == plantillaProductoId);
        }
    }
}
