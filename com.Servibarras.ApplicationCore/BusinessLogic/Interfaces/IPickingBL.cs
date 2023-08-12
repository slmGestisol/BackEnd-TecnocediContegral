using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPickingBL
    {
        DataSet SPPickingRuteo(JObject pickingJson);
        DataSet SetPickingPackingRuteo(JArray pickingPackingJson);
        DataSet getPickingPackingByRuteo(long ruteoId,long ruteoDetalleId);
        DataSet SetPickingPackingRuteoNovedad(JArray pickingNovedad);
    }
}