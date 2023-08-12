using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CriterioProductoBL : ICriterioProductoBL
    {
        private readonly ICriterioProductoDAL _criterioProductoDAL;
        public CriterioProductoBL(ICriterioProductoDAL criterioProductoDAL)
        {
            this._criterioProductoDAL = criterioProductoDAL;
        }

        public async Task<IEnumerable<CriteriosProductos>> GetCriteriosProductosAsync()
        {
            return await this._criterioProductoDAL.GetCriteriosProductosAsync();
        }



        public async Task<CriteriosProductos> GetCriterioProductoAsync(long id)
        {
            return await this._criterioProductoDAL.GetCriterioProductosAsync(id);
        }




        public void AddCriterioProducto(CriteriosProductos criterioProducto)
        {
            this._criterioProductoDAL.AddCriterioProducto(criterioProducto);

        }

        public void DeleteCriterioProducto(long id)
        {
            this._criterioProductoDAL.DeleteCriterioProducto(id);

        }

        public bool CriterioProductoExists(long id)
        {
            return this._criterioProductoDAL.CriterioProductoExists(id);
        }
    }
}
