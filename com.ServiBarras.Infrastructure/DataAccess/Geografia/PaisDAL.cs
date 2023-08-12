using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PaisDAL : IPaisDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public PaisDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Paises>> GetPaisesAsync()
        {
            try


            {
                return await dbcontext.Paises.ToListAsync();

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }


        }



        public async Task<Paises> GetPaisAsync(long id)
        {
            try
            {
                var paises = await dbcontext.Paises.FindAsync(id);
                return paises;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task UpdatePaisAsync(long id, Paises pais)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {


        }


        public void AddPais(Paises pais)
        {
            try
            {
                dbcontext.Paises.Add(pais);
                dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }
        }

        public void DeletePais(long id)
        {

        }

        public bool PaisExists(long id)
        {
            try
            {
                return dbcontext.Paises.Any(e => e.paisId == id);

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }
        }
    }
}






