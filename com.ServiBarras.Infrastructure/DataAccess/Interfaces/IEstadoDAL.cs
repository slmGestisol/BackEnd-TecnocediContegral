using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IEstadoDAL
    {
        void AddEstado(Estados estado);
        void DeleteEstado(long id);
        bool EstadoExists(long id);
        Task<Estados> GetEstadoAsync(long id);
        Task<List<Estados>> GetEstadosAsync();
        Task UpdateEstadoAsync(long id, Estados estado);
    }
}