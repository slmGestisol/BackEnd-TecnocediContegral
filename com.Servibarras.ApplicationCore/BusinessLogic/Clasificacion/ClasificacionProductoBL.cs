using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ClasificacionProductoBL : IClasificacionProductoBL
    {
        private readonly IClasificacionProductoDAL _clasificacionProductoDAL;

        public ClasificacionProductoBL(IClasificacionProductoDAL clasificacionProductoDAL)
        {
            this._clasificacionProductoDAL = clasificacionProductoDAL;
        }

        public async Task<IEnumerable<ClasificacionesProductos>> GetClasificacionProductosAsync()
        {            
            return await this._clasificacionProductoDAL.GetClasificacionProductosAsync();
        }



        public async Task<ClasificacionesProductos> GetClasificacionProductoAsync(long id)
        {           
            return await this._clasificacionProductoDAL.GetClasificacionProductoAsync(id);
        }



        public void AddClasificacionProducto(JObject clasificacionProductoJson)
        {
            ClasificacionesProductos clasificacionProducto = new ClasificacionesProductos();

            var clasificacionProductoAux = JsonConvert.DeserializeObject<ClasificacionProductoDTO>(clasificacionProductoJson.ToString());

            clasificacionProducto.clasificacionProductoDescripcion = clasificacionProductoAux.clasificacionProductoDescripcion;
            clasificacionProducto.clasificacionProductoEstado = (byte)EntityEnum.ClasificacionProductoEstado.Bloqueado;



            this._clasificacionProductoDAL.AddClasificacionProducto(clasificacionProducto);

        }

        public void DeleteClasificacionProducto(long id)
        {           
            this._clasificacionProductoDAL.DeleteClasificacionProducto(id);
        }

        public bool ClasificacionProductoExists(long id)
        {           
            return this._clasificacionProductoDAL.ClasificacionProductoExists(id);
        }
    }
}
