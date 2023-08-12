using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IUnidadManejoBL
    {
        void AddUnidadManejo(JObject unidadManejo);
        void DeleteUnidadManejo(long id);
        Task<IEnumerable<UnidadesManejo>> GetUnidadesManejoAsync();
        Task<UnidadesManejo> GetUnidadManejoAsync(long id);
        bool UnidadManejoExists(long id);
    }
}