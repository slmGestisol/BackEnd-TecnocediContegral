using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPreRuteoDAL
    {
        void CancelPreruteo(PreRuteoItemDTO prereRuteoAux);
        void AddPreRuteos(PreRuteos preRuteo);
        void DeletePreRuteos(long preRuteoId);
        //Task<List<PreRuteos>> GetPreRuteosAsync();
        DataSet GetPreRuteos();
        Task<List<PreRuteos>> GetPreRuteoAsync(long preRuteoId);
        DataSet GetPreRuteoDetalle(long preRuteoId);
        bool PreRuteosIdExists(long preRuteoId);
        DataSet SPProcessPreRuteo(PreRuteoDTO preRuteoDTO);
        Task UpdatePreRuteosAsync(long preRuteoId, PreRuteos preRuteo);
        void AddPedidosPreRuteo(List<PedidosPreRuteoDTO> pedidosPreRuteolist);
        Task<List<Pedidos>> GetPedidosPreRuteo(long preRuteoId);

        DataSet GetPreRuteoNovedades(long preRuteoId);
        DataSet SetPreruteoCrossDocking(PreRuteoNovedadesDTO preRuteoDTO);
        DataSet GetPedidoSecuencial();

        DataSet getPedidoOrdenConfiguracion(long preruteoId);

        DataSet setPedidoConfiguracionOrden(List<PedidosConfiguracionOrdenDTO> pedidosConfiguracionOrdenDTO);

        DataSet addpedidosDetalleCrossDocking(List<PedidosDetalleCrossDockingDTO> parametrosPedidosDetalleCrossDocking);
    }
}