using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IOrdenanteDAL
    {
        Task<List<Ordenantes>> GetOrdenantesAsync();
        Task<Ordenantes> GetOrdenanteAsync(long id);
        void AddOrdenante(Ordenantes ordenante);
    }
}