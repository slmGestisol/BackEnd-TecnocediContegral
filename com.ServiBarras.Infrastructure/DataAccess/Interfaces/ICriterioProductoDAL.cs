using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICriterioProductoDAL
    {
        void AddCriterioProducto(CriteriosProductos criterioProducto);
        bool CriterioProductoExists(long id);
        void DeleteCriterioProducto(long id);
        Task<CriteriosProductos> GetCriterioProductosAsync(long id);
        Task<List<CriteriosProductos>> GetCriteriosProductosAsync();
        Task UpdateCriterioProductoAsync(long id, CriteriosProductos criterioProducto);
    }
}