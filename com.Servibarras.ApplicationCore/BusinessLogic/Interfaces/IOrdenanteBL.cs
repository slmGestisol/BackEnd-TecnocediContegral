using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IOrdenanteBL
    {
        Task<List<Ordenantes>> GetOrdenantesAsync();
        Task<Ordenantes> GetOrdenanteAsync(long id);

        void AddOrdenante(JObject ordenanteJson);
    }
}