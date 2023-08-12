using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
////using com.ServiBarras.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CiudadDAL : ICiudadDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public CiudadDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta las ciudades
        /// </summary>
        /// <returns></returns>
        public async Task<List<Ciudades>> GetCiudadesAsync()
        {
            return await dbcontext.Ciudades.ToListAsync();
        }
        /// <summary>
        /// Método que consulta una ciudad según el ciudadId
        /// </summary>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        public async Task<Ciudades> GetCiudadAsync(long ciudadId)
        {
            var ciudad = await dbcontext.Ciudades.FindAsync(ciudadId);
            return ciudad;
        }
        /// <summary>
        /// Método que actualiza una ciudad según el ciudadId
        /// </summary>
        /// <param name="ciudadId"></param>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        public async Task UpdateCiudadAsync(long ciudadId, Ciudades ciudad)
        {
            if (ciudadId != ciudad.ciudadId)
            {

            }

            dbcontext.Entry(ciudad).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!CiudadExists(ciudadId))
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
        /// <param name="ciudad"></param>
        public void AddCiudad(Ciudades ciudad)
        {
            dbcontext.Ciudades.Add(ciudad);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina una ciudad 
        /// </summary>
        /// <param name="ciudadId"></param>
        public void DeleteCiudad(long ciudadId)
        {
            var ciudad = dbcontext.Ciudades.Find(ciudadId);
            if (ciudad == null)
            {

            }

            dbcontext.Ciudades.Remove(ciudad);
            dbcontext.SaveChanges();


        }
        /// <summary>
        /// Método que valida si existe o no una ciudad
        /// </summary>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        public bool CiudadExists(long ciudadId)
        {
            return dbcontext.Ciudades.Any(e => e.ciudadId == ciudadId);
        }
    }
}