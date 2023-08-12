using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
////using com.ServiBarras.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class OrdenanteDAL : IOrdenanteDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public OrdenanteDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Ordenantes>> GetOrdenantesAsync()
        {
            return await dbcontext.Ordenantes.ToListAsync();
        }



        public async Task<Ordenantes> GetOrdenanteAsync(long id)
        {
            var ordenante = await dbcontext.Ordenantes.FindAsync(id);
            return ordenante;
        }

        public void AddOrdenante(Ordenantes ordenante)
        {
            dbcontext.Ordenantes.Add(ordenante);
            dbcontext.SaveChangesAsync();

        }





    }
}
