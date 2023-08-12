using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICrossDockingBL
    {
        DataSet GetFiltroBahiasProductosCrossDocking(JObject crossDockingParam);
        DataSet SetCrossDockingRuteoDetalle(JObject crossDockingParam);
        DataSet getPickingCrossDocking();
        DataSet GetCodigoUbicacionByUsuarioIdCrossDocking(JObject crossDockingParam);
        DataSet GetSaldoDetalleRuteoCrossDocking(JObject saldoDetalleRuteoCrossDockingParam);
    }
}