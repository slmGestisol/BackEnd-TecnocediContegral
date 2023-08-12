using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPedidoBL
    {
        Task<Pedidos> GetPedidoAsync(long PedidoId);
        bool ActualizarPedidoEstado(JObject pedidoJson);
        DataSet GetPedidos(long instalacionId);
        DataSet GetPedidoDetalle(long pedidoId);
        bool SetCargarPedidos();

    }
}