using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PlantillaLoteDAL : IPlantillaLoteDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public PlantillaLoteDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta las plantillasLotes
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlantillasLotes>> GetPlantillasLotesAsync()
        {
            return await dbcontext.PlantillasLotes.ToListAsync();
        }
        /// <summary>
        /// Método que consulta una plantillaLote según el plantillaLoteId
        /// </summary>
        /// <param name="plantillaLoteId"></param>
        /// <returns></returns>
        public async Task<PlantillasLotes> GetPlantillaLoteAsync(long plantillaLoteId)
        {
            var plantillaLote = await dbcontext.PlantillasLotes.FindAsync(plantillaLoteId);
            return plantillaLote;
        }
        /// <summary>
        /// Método que actualiza una ciudad según el ciudadId
        /// </summary>
        /// <param name="plantillaLoteId"></param>
        /// <param name="plantillaLote"></param>
        /// <returns></returns>
        public async Task UpdatePlantillaLoteAsync(long plantillaLoteId, PlantillasLotes plantillaLote)
        {
            if (plantillaLoteId != plantillaLote.plantillaLoteId)
            {

            }

            dbcontext.Entry(plantillaLote).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!PlantillaLoteIdExists(plantillaLoteId))
                {

                }
                else
                {
                    throw;
                }
            }


        }

        /// <summary>
        /// Método que inserta una ciudad en la tabla ciudades
        /// </summary>
        /// <param name="plantillaLote"></param>
        public void AddPlantillaLote(PlantillasLotes plantillaLote)
        {
            dbcontext.PlantillasLotes.Add(plantillaLote);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina una plantillaLote 
        /// </summary>
        /// <param name="plantillaLoteId"></param>
        public void DeletePlantillaLote(long plantillaLoteId)
        {
            var plantillaLote = dbcontext.PlantillasLotes.Find(plantillaLoteId);
            if (plantillaLote == null)
            {

            }

            dbcontext.PlantillasLotes.Remove(plantillaLote);
            dbcontext.SaveChanges();


        }
        /// <summary>
        /// Método que valida si existe o no una plantillaLote
        /// </summary>
        /// <param name="plantillaLoteId"></param>
        /// <returns></returns>
        public bool PlantillaLoteIdExists(long plantillaLoteId)
        {
            return dbcontext.PlantillasLotes.Any(e => e.plantillaLoteId == plantillaLoteId);
        }
    }
}