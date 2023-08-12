using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class UnidadEscalarDAL : IUnidadEscalarDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public UnidadEscalarDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<UnidadesEscalares>> GetUnidadesEscalarAsync()
        {
            return await dbcontext.UnidadesEscalares.ToListAsync();
        }



        public async Task<UnidadesEscalares> GetUnidadEscalarAsync(long? id)
        {
            var UnidadEscalars = await dbcontext.UnidadesEscalares.FindAsync(id);
            return UnidadEscalars;
        }

        public async Task UpdateUnidadEscalarsAsync(long id, UnidadesEscalares unidadEscalar)
        {
            if (id != unidadEscalar.unidadEscalarId)
            {

            }

            dbcontext.Entry(unidadEscalar).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!UnidadEscalarExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddUnidadEscalar(UnidadesEscalares unidadEscalar)
        {
            dbcontext.UnidadesEscalares.Add(unidadEscalar);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteUnidadEscalar(long id)
        {
            var UnidadEscalar = dbcontext.UnidadesEscalares.Find(id);
            if (UnidadEscalar == null)
            {

            }

            dbcontext.UnidadesEscalares.Remove(UnidadEscalar);
            dbcontext.SaveChanges();


        }

        public bool UnidadEscalarExists(long id)
        {
            return dbcontext.UnidadesEscalares.Any(e => e.unidadEscalarId == id);
        }
    }
}
