using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IAtributoProductoBL
    {
        void AddAtributoProducto(AtributosProductos atributosProducto);
        bool atributosProductoExists(long atributoProductoId);
        void DeleteAtributosProducto(long atributoProductoId);
        Task<AtributosProductos> GetAtributosProductoAsync(long atributoProductoId);
        Task<List<AtributosProductos>> GetAtributosProductosAsync();

    }
}