using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICustodioDAL
    {
        Task<Custodios> GetCustodioAsync(long id);
        Task<List<Custodios>> GetCustodiosAsync();
        Task AddCustodioAsync(Custodios custodio);


    }
}