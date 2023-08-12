using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PuntoOperacionDAL : IPuntoOperacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public PuntoOperacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        /// <summary>
        /// Método que consulta los Puntos de operación
        /// </summary>
        /// <returns></returns>
        public async Task<List<PuntosOperaciones>> GetPuntosOperacionAsync()
        {
            return await dbcontext.PuntosOperaciones.ToListAsync();
        }


        /// <summary>
        /// Método que consulta un Punto de operación según el PuntoOperacionId
        /// </summary>
        /// <param name="PuntoOperacionId"></param>
        /// <returns></returns>
        public async Task<PuntosOperaciones> GetPuntoOperacionAsync(long puntoOperacionId)
        {
            var puntoOperacion = await dbcontext.PuntosOperaciones.FindAsync(puntoOperacionId);
            return puntoOperacion;
        }
        /// <summary>
        /// Método que actualiza un Punto de operación según el PuntoOperacionId
        /// </summary>
        /// <param name="PuntoOperacionId"></param>
        /// <param name="PuntoOperacion"></param>
        /// <returns></returns>
        public async Task UpdatePuntoOperacionsAsync(long puntoOperacionId, PuntosOperaciones puntoOperacion)
        {
            if (puntoOperacionId != puntoOperacion.puntoOperacionId)
            {

            }

            dbcontext.Entry(puntoOperacion).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!PuntoOperacionExists(puntoOperacionId))
                {

                }
                else
                {
                    throw;
                }
            }


        }
        /// <summary>
        /// Método que inserta un Punto de operación 
        /// </summary>
        /// <param name="PuntoOperacion"></param>
        public void AddPuntoOperacion(PuntosOperaciones puntoOperacion)
        {
            dbcontext.PuntosOperaciones.Add(puntoOperacion);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina un Punto de operación según el PuntoOperacionId
        /// </summary>
        /// <param name="PuntoOperacionId"></param>
        public void DeletePuntoOperacion(long puntoOperacionId)
        {
            var puntoOperacion = dbcontext.PuntosOperaciones.Find(puntoOperacionId);
            if (puntoOperacion == null)
            {

            }

            dbcontext.PuntosOperaciones.Remove(puntoOperacion);
            dbcontext.SaveChanges();


        }
        /// <summary>
        /// Método que valida si existe o no un Punto operación
        /// </summary>
        /// <param name="PuntoOperacionId"></param>
        /// <returns></returns>
        public bool PuntoOperacionExists(long puntoOperacionId)
        {
            return dbcontext.PuntosOperaciones.Any(e => e.puntoOperacionId == puntoOperacionId);
        }
    }
}
