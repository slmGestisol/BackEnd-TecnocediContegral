using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IAtributoProductoDAL
    {
        void AddAtributoProducto(AtributosProductos atributosProducto);
        bool AtributosProductoExists(long atributoProductoId);
        void DeleteAtributosProducto(long atributoProductoId);
        Task<AtributosProductos> GetAtributosProductoAsync(long atributoProductoId);
        Task<List<AtributosProductos>> GetAtributosProductosAsync();
        Task UpdateAtributosProductosAsync(long id, AtributosProductos atributosProducto);
    }
}