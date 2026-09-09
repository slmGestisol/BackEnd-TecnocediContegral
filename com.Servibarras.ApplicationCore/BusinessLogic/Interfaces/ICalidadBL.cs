using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICalidadBL
    {
        DataSet GetCalidadSaldosUbicaciones(long instalacionId);
        DataSet SetCalidadUbicaciones(JObject parametrosCalidad);
    }
}