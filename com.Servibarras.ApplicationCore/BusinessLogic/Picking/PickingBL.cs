using System.Collections.Generic;
using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PickingBL : IPickingBL
    {
        private readonly IPickingDAL _pickingDAL;
        public PickingBL(IPickingDAL pickingDAL)
        {
            this._pickingDAL = pickingDAL;
        }

        public DataSet SPPickingRuteo(JObject pickingJson)
        {
            var pickingAux = JsonConvert.DeserializeObject<PickingDTO>(pickingJson.ToString());
            return this._pickingDAL.SPPickingRuteo(pickingAux);
        }

        public DataSet SetPickingPackingRuteo(JArray pickingPackingJson)
        {
            var pickingPackingAux = JsonConvert.DeserializeObject<List<PickingPackingDTO>>(pickingPackingJson.ToString());
            return this._pickingDAL.SetPickingPackingRuteo(pickingPackingAux);
        }
        public DataSet getPickingPackingByRuteo(long ruteoId, long ruteoDetalleId)
        {
            return this._pickingDAL.getPickingPackingByRuteo(ruteoId, ruteoDetalleId);
        }
        public DataSet SetPickingPackingRuteoNovedad(JArray pickingNovedad)
        {
            var pickingPackingNovedadAux = JsonConvert.DeserializeObject<List<PickingPackingNovedadDTO>>(pickingNovedad.ToString());
            return this._pickingDAL.SetPickingPackingRuteoNovedad(pickingPackingNovedadAux);
        }
    }
}
