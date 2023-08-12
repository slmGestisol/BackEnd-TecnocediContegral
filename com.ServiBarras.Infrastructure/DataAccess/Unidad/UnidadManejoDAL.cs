using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class UnidadManejoDAL : IUnidadManejoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public UnidadManejoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<UnidadesManejo>> GetUnidadesManejoAsync()
        {
            return await dbcontext.UnidadesManejo.ToListAsync();
        }



        public async Task<UnidadesManejo> GetUnidadManejoAsync(long? id)
        {
            var UnidadManejos = await dbcontext.UnidadesManejo.FindAsync(id);
            return UnidadManejos;
        }

        public async Task UpdateUnidadManejosAsync(long id, UnidadesManejo UnidadManejo)
        {
            if (id != UnidadManejo.unidadManejoId)
            {

            }

            dbcontext.Entry(UnidadManejo).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!UnidadManejoExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddUnidadManejo(UnidadesManejo UnidadManejo)
        {
            dbcontext.UnidadesManejo.Add(UnidadManejo);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteUnidadManejo(long id)
        {
            var UnidadManejo = dbcontext.UnidadesManejo.Find(id);
            if (UnidadManejo == null)
            {

            }

            dbcontext.UnidadesManejo.Remove(UnidadManejo);
            dbcontext.SaveChanges();


        }

        public bool UnidadManejoExists(long id)
        {
            return dbcontext.UnidadesManejo.Any(e => e.unidadManejoId == id);
        }
    }
}
