using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class AtributoProductoBL : IAtributoProductoBL
    {
        private readonly IAtributoProductoDAL atributoProductoDAL;

        public AtributoProductoBL(IAtributoProductoDAL atributoProductoDAL)
        {
            this.atributoProductoDAL = atributoProductoDAL;
        }
        public async Task<List<AtributosProductos>> GetAtributosProductosAsync()
        {
            
            return await this.atributoProductoDAL.GetAtributosProductosAsync();
        }



        public async Task<AtributosProductos> GetAtributosProductoAsync(long atributoProductoId)
        {
           
            return await this.atributoProductoDAL.GetAtributosProductoAsync(atributoProductoId);
        }



        public void AddAtributoProducto(AtributosProductos atributosProducto)
        {

            this.atributoProductoDAL.AddAtributoProducto(atributosProducto);

        }

        public void DeleteAtributosProducto(long atributoProductoId)
        {



        }

        public bool atributosProductoExists(long atributoProductoId)
        {
           
            return this.atributoProductoDAL.AtributosProductoExists(atributoProductoId);
        }
    }
}
