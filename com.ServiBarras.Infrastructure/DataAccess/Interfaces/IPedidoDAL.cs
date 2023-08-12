using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPedidoDAL
    {
        Task<Pedidos> GetPedidoAsync(long PedidoId);
        DataSet GetPedidos(long instalacionId);
        bool PedidoIdExists(long? PedidoId);
        DataSet GetPedidoDetalle(long pedidoId);
        bool ActualizarPedidoEstado(PedidoDTO pedido);
        bool SetCargarPedidos();

    }
}