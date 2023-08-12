using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPackingBL
    {
        DataSet SPPackingRuteo(JObject packingJson);
        DataSet GetPackingDetallebyPackingId(JObject packingJson);
    }
}