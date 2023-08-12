using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CentroGestionDAL : ICentroGestionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public CentroGestionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta todos los centros de gestion
        /// </summary>
        /// <returns></returns>
        public async Task<List<CentrosGestion>> GetCentrosGestionAsync()
        {
            return await dbcontext.CentrosGestion.ToListAsync();
        }
        /// <summary>
        /// Método que consulta el centro de gestión por centroGestionId
        /// </summary>
        /// <param name="centroGestionId"></param>
        /// <returns></returns>
        public async Task<CentrosGestion> GetCentroGestionAsync(long centroGestionId)
        {
            var CentroGestions = await dbcontext.CentrosGestion.FindAsync(centroGestionId);
            return CentroGestions;
        }
        /// <summary>
        /// Método que actualiza el centro de gestión seleccionado
        /// </summary>
        /// <param name="centroGestionId"></param>
        /// <param name="centroGestion"></param>
        /// <returns></returns>
        public async Task UpdateCentroGestionsAsync(long centroGestionId, CentrosGestion centroGestion)
        {
            if (centroGestionId != centroGestion.centroGestionId)
            {

            }

            dbcontext.Entry(centroGestion).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!CentroGestionExists(centroGestionId))
                {

                }
                else
                {
                    throw;
                }
            }

        }
        /// <summary>
        /// Método que agrega un centro de gestión
        /// </summary>
        /// <param name="centroGestion"></param>
        public void AddCentroGestion(CentrosGestion centroGestion)
        {
            dbcontext.CentrosGestion.Add(centroGestion);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina el centro de gestión seleccionado
        /// </summary>
        /// <param name="centroGestionId"></param>
        public void DeleteCentroGestion(long centroGestionId)
        {
            var centroGestion = dbcontext.CentrosGestion.Find(centroGestionId);
            if (centroGestion == null)
            {

            }

            dbcontext.CentrosGestion.Remove(centroGestion);
            dbcontext.SaveChanges();
        }
        /// <summary>
        /// Método que valida si existe o no un centro de gestión
        /// </summary>
        /// <param name="centroGestionId"></param>
        /// <returns></returns>
        public bool CentroGestionExists(long centroGestionId)
        {
            return dbcontext.CentrosGestion.Any(e => e.centroGestionId == centroGestionId);
        }
    }
}
