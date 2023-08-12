using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IUnidadEscalarBL
    {
        void AddUnidadEscalar(JObject unidadEscalarJson);
        void DeleteUnidadEscalar(long id);
        Task<UnidadesEscalares> GetUnidadEscalarAsync(long id);
        Task<IEnumerable<UnidadesEscalares>> GetUnidadesEscalaresAsync();
        bool UnidadEscalarExists(long id);

    }
}