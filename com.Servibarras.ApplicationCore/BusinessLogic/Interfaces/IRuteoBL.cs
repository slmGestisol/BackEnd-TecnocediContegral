using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IRuteoBL
    {
        DataSet GetRuteoDetalle(JObject parametrosRuteod);
        Task<List<Ruteos>> GetRuteosAsync();
        DataSet GetRuteosByInstalacionIdAsync(long instalacionId);
        Task<Ruteos> GetRuteosAsync(long preRuteoId);
        Task<RuteosDetalle> GetRuteosDetalleItemAsync(long ruteoDetalleId);
        DataSet SP_Add_Ruteo(JObject ruteoJson);
        DataSet SP_Add_NovedadRuteo(JObject parametrosRuteo);
        DataSet GetRuteoDetalleFilters(JObject parametrosRuteo);

        DataSet GetRuteosPedidosBahiasbyRuteoId(long ruteoId);
        DataSet GetRuteosPedidosProductosbyRuteoId(long ruteoId);

        DataSet GetFiltroBahiasProductosRuteo(JObject parametrosRuteo);

        DataSet GetRuteoPedidosInfo(long ruteoId);

        DataSet GetAsignacionBahiasRuteoId(int ruteoId);
        DataSet PackingDetalleUsuarioId(long? usuarioId);
    }
}