using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICustodioBL
    {
        Task<Custodios> GetCustodioAsync(long id);
        Task<List<Custodios>> GetCustodiosAsync();
        Task AddCustodioAsync(JObject custodioJson);
    }
}