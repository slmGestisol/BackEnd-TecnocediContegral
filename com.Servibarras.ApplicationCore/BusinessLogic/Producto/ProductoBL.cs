using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ProductoBL : IProductoBL
    {


        private readonly IProductoDAL _productoDAL;
        public ProductoBL(IProductoDAL productoDAL)
        {
            this._productoDAL = productoDAL;
        }
        /// <summary>
        ///  Método que consulta los productos existente
        /// </summary>
        /// <returns></returns>
        public DataSet GetProductosAsync()
        {
            return  this._productoDAL.GetProductosAsync();
        }
        /// <summary>
        /// Método que consulta los productos existente por productoId
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public async Task<Productos> GetProductoAsync(long productoId)
        {
            return await this._productoDAL.GetProductoAsync(productoId);
        }
        /// <summary>
        /// Método que actualiza el producto seleccionado según el productoId
        /// </summary>
        /// <param name="productoId">productoId</param>
        /// <param name="producto"></param>
        /// <returns></returns>


        /// <summary>
        /// Método que inserta un producto en la tabla productos
        /// </summary>
        /// <param name="producto"></param>
        public async Task AddProducto(JObject productoJson)
        {
            try
            {
                Productos producto = new Productos();
                var productoAux = JsonConvert.DeserializeObject<ProductoDto>(productoJson.ToString());

                producto.productoCodigo = productoAux.productoCodigo;
                producto.productoDescripcion = productoAux.productoDescripcion;
                producto.productoCantidadManejo = Convert.ToInt32(productoAux.productoCantidadManejo);
                producto.productoUnidadInventario = Convert.ToByte(productoAux.productoUnidadInventario);
                producto.productoManejaLote = Convert.ToByte(productoAux.productoManejaLote);
                producto.productoEstado = Convert.ToByte(productoAux.productoEstado);
                producto.productoCodigoAlternativo = productoAux.productoCodigoAlternativo;
                producto.productoManejaDimension = Convert.ToByte(productoAux.productoManejaDimension);
                producto.titularId = 2;
                producto.unidadManejoId = 1;
                producto.unidadEscalarId = 1;
                producto.productoTipo = 1;


                await this._productoDAL.AddProducto(producto);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }

        }
        /// <summary>
        /// Método que elimina un producto seleccionado según el productoId 
        /// </summary>
        /// <param name="productoId"></param>
        public void DeleteProducto(long productoId)
        {
            this._productoDAL.DeleteProducto(productoId);

        }
        /// <summary>
        /// Método que valida si existe o no un producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public bool ProductoExists(long productoId)
        {
            return this._productoDAL.ProductoExists(productoId);
        }


        public async Task<List<DetalleProducto>> GetDetalleProductosAsync()
        {
            return await this._productoDAL.GetDetalleProductosAsync();

        }

        public async Task<DetalleProducto> GetDetalleProductoByIdAsync(long productoId)
        {
            return await this._productoDAL.GetDetalleProductoByIdAsync(productoId);


        }
    }
}
