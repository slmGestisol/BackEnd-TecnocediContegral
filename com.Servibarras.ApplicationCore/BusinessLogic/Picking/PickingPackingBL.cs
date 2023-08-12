using System.Collections.Generic;
using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PickingPackingBL : IPickingPackingBL
    {
        private readonly IPickingPackingDAL _pickingPackingDAL;
        public PickingPackingBL(IPickingPackingDAL pickingPackingDAL)
        {
            this._pickingPackingDAL = pickingPackingDAL;
        }

        public DataSet SetPickingPackingRuteo(JArray pickingPackingJson)
        {
            var pickingPackingAux = JsonConvert.DeserializeObject<List<PickingPackingDTO>>(pickingPackingJson.ToString());
            return this._pickingPackingDAL.SetPickingPackingRuteo(pickingPackingAux);
        }


    }
}
