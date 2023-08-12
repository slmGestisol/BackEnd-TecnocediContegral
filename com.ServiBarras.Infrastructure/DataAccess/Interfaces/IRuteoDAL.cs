using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IRuteoDAL
    {
        Task<Ruteos> GetRuteoAsync(long ruteoId);
        Task<List<Ruteos>> GetRuteosAsync();
        DataSet GetRuteosByInstalacionIdAsync(long instalacionId);
        DataSet GetRuteoDetalle(long ruteoId, long? ruteoDetalleId);
        DataSet SP_Add_Ruteo(long preRuteoId, long usuarioId);
        DataSet SP_Add_RuteoDetalle(long ruteoId, long usuarioId);
        void SP_Update_RuteoGrupos(long preRuteoId, List<RuteoGrupoDTO> ruteosGrupos);
        void SP_Update_RuteoPedidosOrdenBahias(long preRuteoId, List<PedidoOrdenBahiaInfoDTO> pedidoOrdenBahiaInfo);
        Task<RuteosDetalle> GetRuteosDetalleItemAsync(long ruteoDetalleId);
        DataSet GetRuteoDetalleFilters(RuteoDetalleDTO ruteoAux);
        DataSet GetAsignacionBahiasRuteoId(int ruteoId);

        DataSet GetRuteosPedidosBahiasbyRuteoId(long ruteoId);
        DataSet GetRuteosPedidosProductosbyRuteoId(long ruteoId);
        DataSet GetFiltroBahiasProductosRuteo(RuteoBahiaProductoFilterDTO ruteoAux);
        void AddRuteosPedidosDetalleEstado(long ruteoId);

        DataSet SP_Add_NovedadRuteo(long novedadId, long ruteoId, long ruteoDetalleId, long usuarioId);
        DataSet GetRuteoPedidosInfo(long ruteoId);
    }
}