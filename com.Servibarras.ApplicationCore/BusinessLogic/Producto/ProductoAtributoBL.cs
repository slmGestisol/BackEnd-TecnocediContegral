using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ProductoAtributoBL : IProductoAtributoBL
    {
        private readonly IProductoAtributoDAL _productoAtributoDAL;
        public ProductoAtributoBL(IProductoAtributoDAL productoAtributoDAL)
        {
            this._productoAtributoDAL = productoAtributoDAL;
        }
        public async Task<List<ProductosAtributos>> GetProductosAtributosAsync()
        {
            return await this._productoAtributoDAL.GetProductosAtributosAsync();
        }



        public async Task<ProductosAtributos> GetProductoAtributoAsync(long productoAtributoId)
        {
            return await this._productoAtributoDAL.GetProductoAtributoAsync(productoAtributoId);
        }

       

        public void AddProductoAtributo(JObject productoAtributoJson)
        {
            try
            {
                ProductosAtributos productoAtributo = new ProductosAtributos();

                var productoAtributoAux = JsonConvert.DeserializeObject<ProductoAtributoDTO>(productoAtributoJson.ToString());

                productoAtributo.productoId = Convert.ToInt64(productoAtributoAux.productoId);
                productoAtributo.productoPlantillaId = Convert.ToInt64(productoAtributoAux.productoPlantillaId);
                productoAtributo.productoAtributoValor = productoAtributoAux.productoAtributoValor;
                this._productoAtributoDAL.AddProductoAtributo(productoAtributo);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }


        }

        //public void DeleeProductoAtributo(long atributoProductoId)
        //{
        //    var ProductoAtributo = dbcontext.ProductosAtributos.Find(atributoProductoId);
        //    if (ProductoAtributo == null)
        //    {

        //    }

        //    dbcontext.ProductosAtributos.Remove(ProductoAtributo);
        //    dbcontext.SaveChanges();


        //}

        public bool ProductoAtributoExists(long productoId, long productoPlantillaId)
        {
            return this._productoAtributoDAL.ProductoAtributoExists(productoId, productoPlantillaId);
        }
    }
}
