using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class IdentificacionDAL : IIdentificacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public IdentificacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Identificaciones>> GetIdentificacionesAsync()
        {
            return await dbcontext.Identificaciones.ToListAsync();
        }



        public async Task<Identificaciones> GetIdentificacionAsync(long id)
        {
            var identificacion = await dbcontext.Identificaciones.FindAsync(id);
            return identificacion;
        }

        public async Task UpdateIdentificacionAsync(long id, Identificaciones identificacion)
        {
            if (id != identificacion.identificacionId)
            {

            }

            dbcontext.Entry(identificacion).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!IdentificacionExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddIdentificacion(Identificaciones identificacion)
        {
            dbcontext.Identificaciones.Add(identificacion);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteIdentificacion(long id)
        {
            var identificacion = dbcontext.Identificaciones.Find(id);
            if (identificacion == null)
            {

            }

            dbcontext.Identificaciones.Remove(identificacion);
            dbcontext.SaveChanges();


        }

        public bool IdentificacionExists(long id)
        {
            return dbcontext.Identificaciones.Any(e => e.identificacionId == id);
        }
    }
}
