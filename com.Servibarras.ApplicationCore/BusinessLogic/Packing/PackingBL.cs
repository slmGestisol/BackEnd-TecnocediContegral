using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PackingBL : IPackingBL
    {

        private readonly IPackingDAL _packingDAL;
        public PackingBL(IPackingDAL packingDAL)
        {
            this._packingDAL = packingDAL;
        }

        public DataSet SPPackingRuteo(JObject packingJson)
        {
            var packingAux = JsonConvert.DeserializeObject<PackingDTO>(packingJson.ToString());
            return this._packingDAL.SPPackingRuteo(packingAux);
        }

        public DataSet GetPackingDetallebyPackingId(JObject packingJson)
        {
            var packingAux = JsonConvert.DeserializeObject<PackingDetalleDTO>(packingJson.ToString());
            return this._packingDAL.GetPackingDetallebyPackingId(packingAux);
        }
    }
}
