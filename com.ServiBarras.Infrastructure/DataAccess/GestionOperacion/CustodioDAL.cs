using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
//using com.ServiBarras.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CustodioDAL : ICustodioDAL
    {
        public TecnoCEDI_bdContext dbcontext;


        public CustodioDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Custodios>> GetCustodiosAsync()
        {
            return await dbcontext.Custodios.ToListAsync();
        }



        public async Task<Custodios> GetCustodioAsync(long id)
        {
            var Custodio = await dbcontext.Custodios.FindAsync(id);
            return Custodio;
        }


        public async Task AddCustodioAsync(Custodios custodio)
        {
            await dbcontext.Custodios.AddAsync(custodio);
        }




    }
}