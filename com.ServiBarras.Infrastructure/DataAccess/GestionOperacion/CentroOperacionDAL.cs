using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
////using com.ServiBarras.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CentroOperacionDAL : ICentroOperacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public CentroOperacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        /// <summary>
        /// Método que consulta los centros de operación
        /// </summary>
        /// <returns></returns>
        public async Task<List<CentrosOperaciones>> GetCentrosOperacionAsync()
        {
            return await dbcontext.CentrosOperaciones.ToListAsync();
        }


        /// <summary>
        /// Método que consulta un centro de operación según el centroOperacionId
        /// </summary>
        /// <param name="centroOperacionId"></param>
        /// <returns></returns>
        public async Task<CentrosOperaciones> GetCentroOperacionAsync(long centroOperacionId)
        {
            var CentroOperacions = await dbcontext.CentrosOperaciones.FindAsync(centroOperacionId);
            return CentroOperacions;
        }
        /// <summary>
        /// Método que actualiza un centro de operación según el centroOperacionId
        /// </summary>
        /// <param name="centroOperacionId"></param>
        /// <param name="centroOperacion"></param>
        /// <returns></returns>
        public async Task UpdateCentroOperacionsAsync(long centroOperacionId, CentrosOperaciones centroOperacion)
        {
            if (centroOperacionId != centroOperacion.centroOperacionId)
            {

            }

            dbcontext.Entry(centroOperacion).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!CentroOperacionExists(centroOperacionId))
                {

                }
                else
                {
                    throw;
                }
            }


        }
        /// <summary>
        /// Método que inserta un centro de operación 
        /// </summary>
        /// <param name="centroOperacion"></param>
        public void AddCentroOperacion(CentrosOperaciones centroOperacion)
        {
            dbcontext.CentrosOperaciones.Add(centroOperacion);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina un centro de operación según el centroOperacionId
        /// </summary>
        /// <param name="centroOperacionId"></param>
        public void DeleteCentroOperacion(long centroOperacionId)
        {
            var centroOperacion = dbcontext.CentrosOperaciones.Find(centroOperacionId);
            if (centroOperacion == null)
            {

            }

            dbcontext.CentrosOperaciones.Remove(centroOperacion);
            dbcontext.SaveChanges();


        }
        /// <summary>
        /// Método que valida si existe o no un centro operación
        /// </summary>
        /// <param name="centroOperacionId"></param>
        /// <returns></returns>
        public bool CentroOperacionExists(long centroOperacionId)
        {
            return dbcontext.CentrosOperaciones.Any(e => e.centroOperacionId == centroOperacionId);
        }
    }
}
