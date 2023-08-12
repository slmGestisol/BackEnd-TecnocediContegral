using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PedidoBL : IPedidoBL
    {
        private readonly IPedidoDAL _pedidoDAL;
        public PedidoBL(IPedidoDAL pedidoDAL)
        {
            this._pedidoDAL = pedidoDAL;
        }
        public DataSet GetPedidos(long instalacionId)
        {           
            return this._pedidoDAL.GetPedidos(instalacionId);
        }

        public async Task<Pedidos> GetPedidoAsync(long PedidoId)
        {
            return await this._pedidoDAL.GetPedidoAsync(PedidoId);
        }


        public DataSet GetPedidoDetalle(long pedidoId)
        {
            return this._pedidoDAL.GetPedidoDetalle(pedidoId);
        }

        public bool ActualizarPedidoEstado(JObject pedidoJson)
        {
            var pedidoAux = JsonConvert.DeserializeObject<PedidoDTO>(pedidoJson.ToString());
            return this._pedidoDAL.ActualizarPedidoEstado(pedidoAux);
        }


        public bool SetCargarPedidos()
        {
            return this._pedidoDAL.SetCargarPedidos();
        }
    }
}
