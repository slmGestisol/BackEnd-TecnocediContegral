using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ClasificacionAtributoProductoBL : IClasificacionAtributoProductoBL
    {
        private readonly IClasificacionAtributoProductoDAL _clasificacionAtributoProductoDAL;
        public ClasificacionAtributoProductoBL(IClasificacionAtributoProductoDAL clasificacionAtributoProductoDAL)
        {
            this._clasificacionAtributoProductoDAL = clasificacionAtributoProductoDAL;
        }

        public async Task<IEnumerable<ClasificacionesAtributosProductos>> GetClasificacionAtributoProductosAsync()
        {
            
            return await this._clasificacionAtributoProductoDAL.GetClasificacionAtributosProductosAsync();
        }



        public async Task<ClasificacionesAtributosProductos> GetClasificacionAtributoProductoAsync(long id)
        {
            return await this._clasificacionAtributoProductoDAL.GetClasificacionAtributosProductosAsync(id);
        }




        public void AddClasificacionAtributoProducto(ClasificacionesAtributosProductos clasificacionAtributoProducto)
        {
            this._clasificacionAtributoProductoDAL.AddClasificacionAtributosProductos(clasificacionAtributoProducto);

        }

        public void DeleteClasificacionAtributoProducto(long id)
        {
            this._clasificacionAtributoProductoDAL.DeleteClasificacionAtributosProductos(id);

        }

        public bool ClasificacionAtributoProductoExists(long id)
        {
            return this._clasificacionAtributoProductoDAL.ClasificacionAtributosProductosExists(id);
        }
    }
}
