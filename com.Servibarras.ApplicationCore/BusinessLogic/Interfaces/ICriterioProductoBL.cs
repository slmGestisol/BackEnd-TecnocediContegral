using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICriterioProductoBL
    {
        void AddCriterioProducto(CriteriosProductos criterioProducto);
        bool CriterioProductoExists(long id);
        void DeleteCriterioProducto(long id);
        Task<CriteriosProductos> GetCriterioProductoAsync(long id);
        Task<IEnumerable<CriteriosProductos>> GetCriteriosProductosAsync();

    }
}