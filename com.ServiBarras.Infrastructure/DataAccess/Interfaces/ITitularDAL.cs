using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ITitularDAL
    {
        void AddTitular(Titulares Titular);
        void DeleteTitular(long id);
        Task<Titulares> GetTitularAsync(long? id);
        Task<List<Titulares>> GetTitularesAsync();
        bool TitularExists(long id);
        Task UpdateTitularAsync(long id, Titulares titular);
    }
}