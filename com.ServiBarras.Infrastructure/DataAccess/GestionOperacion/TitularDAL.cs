using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
//using com.ServiBarras.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class TitularDAL : ITitularDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public TitularDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Titulares>> GetTitularesAsync()
        {
            return await dbcontext.Titulares.ToListAsync();
        }



        public async Task<Titulares> GetTitularAsync(long? id)
        {
            try
            {
                var titular = await dbcontext.Titulares.FindAsync(id);
                return titular;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }

        }

        public async Task UpdateTitularAsync(long id, Titulares titular)
        {
            if (id != titular.titularId)
            {

            }

            dbcontext.Entry(titular).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!TitularExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddTitular(Titulares titular)
        {
            dbcontext.Titulares.Add(titular);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteTitular(long id)
        {
            var titular = dbcontext.Titulares.Find(id);
            if (titular == null)
            {

            }

            dbcontext.Titulares.Remove(titular);
            dbcontext.SaveChanges();


        }

        public bool TitularExists(long id)
        {
            return dbcontext.Titulares.Any(e => e.titularId == id);
        }
    }
}
