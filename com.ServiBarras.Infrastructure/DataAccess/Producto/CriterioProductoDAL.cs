using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CriterioProductoDAL : ICriterioProductoDAL
    {

        public TecnoCEDI_bdContext dbcontext;


        public CriterioProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<CriteriosProductos>> GetCriteriosProductosAsync()
        {
            return await dbcontext.CriteriosProductos.ToListAsync();
        }



        public async Task<CriteriosProductos> GetCriterioProductosAsync(long id)
        {
            var CriterioProductos = await dbcontext.CriteriosProductos.FindAsync(id);
            return CriterioProductos;
        }

        public async Task UpdateCriterioProductoAsync(long id, CriteriosProductos criterioProducto)
        {
            if (id != criterioProducto.criterioProductoId)
            {

            }

            dbcontext.Entry(criterioProducto).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!CriterioProductoExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }


        public void AddCriterioProducto(CriteriosProductos criterioProducto)
        {
            dbcontext.CriteriosProductos.Add(criterioProducto);
            dbcontext.SaveChangesAsync();

        }

        public void DeleteCriterioProducto(long id)
        {
            var criterioProducto = dbcontext.CriteriosProductos.Find(id);
            if (criterioProducto == null)
            {

            }

            dbcontext.CriteriosProductos.Remove(criterioProducto);
            dbcontext.SaveChanges();


        }

        public bool CriterioProductoExists(long id)
        {
            return dbcontext.CriteriosProductos.Any(e => e.criterioProductoId == id);
        }
    }
}
