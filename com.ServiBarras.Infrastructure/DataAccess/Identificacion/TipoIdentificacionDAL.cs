using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class TiposIdentificacionDAL : ITiposIdentificacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public TiposIdentificacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<TiposIdentificaciones>> GetTiposIdentificacionesAsync()
        {
            return await dbcontext.TiposIdentificaciones.ToListAsync();
        }



        public async Task<TiposIdentificaciones> GetTipoIdentificacionAsync(long id)
        {
            var tiposIdentificacion = await dbcontext.TiposIdentificaciones.FindAsync(id);
            return tiposIdentificacion;
        }

        public async Task UpdateTipoIdentificacionAsync(long id, TiposIdentificaciones tiposIdentificacion)
        {
            if (id != tiposIdentificacion.tipoIdentificacionId)
            {

            }

            dbcontext.Entry(tiposIdentificacion).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!TipoIdentificacionExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddTipoIdentificacion(TiposIdentificaciones tiposIdentificacion)
        {
            dbcontext.TiposIdentificaciones.Add(tiposIdentificacion);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteTipoIdentificacion(long id)
        {
            var tiposIdentificacion = dbcontext.TiposIdentificaciones.Find(id);
            if (tiposIdentificacion == null)
            {

            }

            dbcontext.TiposIdentificaciones.Remove(tiposIdentificacion);
            dbcontext.SaveChanges();


        }

        public bool TipoIdentificacionExists(long id)
        {
            return dbcontext.TiposIdentificaciones.Any(e => e.tipoIdentificacionId == id);
        }
    }
}
