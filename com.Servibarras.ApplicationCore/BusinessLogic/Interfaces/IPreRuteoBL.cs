using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPreRuteoBL
    {
        void CancelPreruteo(JObject prereRuteoAux);
        void AddPreRuteos(PreRuteos preRuteo);
        void DeletePlantillasProducto(long plantillaProductoId);
        DataSet GetPreRuteos();
        Task<List<PreRuteos>> GetPreRuteoAsync(long preRuteoId);
        DataSet GetPreRuteoDetalle(long preRuteoId);
        bool PreRuteosIdExists(long preRuteoId);
        DataSet SPProcessPreRuteo(JObject preRuteoJson);

        void AddPedidosPreRuteo(JArray pedidosPreRuteolist);
        Task<List<Pedidos>> GetPedidosPreRuteo(long preRuteoId);
        DataSet GetPreRuteoNovedades(long preRuteoId);

        DataSet SetPreruteoCrossDocking(JArray parametrosPreRuteo);
        DataSet GetPedidoSecuencial();

        DataSet getPedidoOrdenConfiguracion(long preruteoId);

        DataSet setPedidoConfiguracionOrden(JArray parametrosPedidosConfiguracionOrden);

        DataSet addpedidosDetalleCrossDocking(JArray parametrosPedidosDetalleCrossDocking);
    }
}