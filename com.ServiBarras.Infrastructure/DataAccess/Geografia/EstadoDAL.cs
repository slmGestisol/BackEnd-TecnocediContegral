using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
////using com.ServiBarras.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class EstadoDAL : IEstadoDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public EstadoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Estados>> GetEstadosAsync()
        {
            try
            {
                return await dbcontext.Estados.ToListAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }

        }



        public async Task<Estados> GetEstadoAsync(long id)
        {
            var estado = await dbcontext.Estados.FindAsync(id);
            return estado;
        }

        public async Task UpdateEstadoAsync(long id, Estados estado)
        {
            if (id != estado.estadoId)
            {

            }

            dbcontext.Entry(estado).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!EstadoExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddEstado(Estados estado)
        {
            dbcontext.Estados.Add(estado);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteEstado(long id)
        {
            var estado = dbcontext.Estados.Find(id);
            if (estado == null)
            {

            }

            dbcontext.Estados.Remove(estado);
            dbcontext.SaveChanges();


        }

        public bool EstadoExists(long id)
        {
            return dbcontext.Estados.Any(e => e.estadoId == id);
        }
    }
}
