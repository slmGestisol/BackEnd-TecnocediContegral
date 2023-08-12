using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ITitularBL
    {
        void AddTitular(JObject titularJson);
        void DeleteTitular(long id);
        Task<Titulares> GetTitularAsync(long id);
        Task<IEnumerable<Titulares>> GetTitularesAsync();
        bool TitularExists(long id);

    }
}