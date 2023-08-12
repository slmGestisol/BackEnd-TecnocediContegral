using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IEstadoBL
    {
        void AddEstado(Estados estado);
        void DeleteEstado(long id);
        bool EstadoExists(long id);
        Task<Estados> GetEstadoAsync(long id);
        Task<List<Estados>> GetEstadosAsync();

    }
}