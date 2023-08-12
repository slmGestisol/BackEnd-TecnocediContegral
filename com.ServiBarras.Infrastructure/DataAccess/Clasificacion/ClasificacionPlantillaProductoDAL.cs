using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ClasificacionPlantillaProductoDAL : IClasificacionPlantillaProductoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public ClasificacionPlantillaProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<ClasificacionesPlantillasProductos>> GetClasificacionesPlantillasProductosAsync()
        {
            return await dbcontext.ClasificacionesPlantillasProductos.ToListAsync();
        }



        public async Task<ClasificacionesPlantillasProductos> GetClasificacionPlantillaProductoAsync(long id)
        {
            var ClasificacionesPlantillasProductoss = await dbcontext.ClasificacionesPlantillasProductos.FindAsync(id);
            return ClasificacionesPlantillasProductoss;
        }

        public async Task UpdateClasificacionPlantillaProductoAsync(long id, ClasificacionesPlantillasProductos clasificacionPlantillaProducto)
        {
            if (id != clasificacionPlantillaProducto.plantillaProductoId)
            {

            }

            dbcontext.Entry(clasificacionPlantillaProducto).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!ClasificacionPlantillaProductoExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddClasificacionPlantillaProducto(ClasificacionesPlantillasProductos clasificacionPlantillaProducto)
        {
            dbcontext.ClasificacionesPlantillasProductos.Add(clasificacionPlantillaProducto);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteClasificacionPlantillaProducto(long id)
        {
            var clasificacionPlantillaProducto = dbcontext.ClasificacionesPlantillasProductos.Find(id);
            if (clasificacionPlantillaProducto == null)
            {

            }

            dbcontext.ClasificacionesPlantillasProductos.Remove(clasificacionPlantillaProducto);
            dbcontext.SaveChanges();


        }

        public bool ClasificacionPlantillaProductoExists(long id)
        {
            return dbcontext.ClasificacionesPlantillasProductos.Any(e => e.plantillaProductoId == id);
        }
    }
}
