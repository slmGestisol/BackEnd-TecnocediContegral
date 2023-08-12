using System.Collections.Generic;
using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPickingPackingDAL
    {
        DataSet SetPickingPackingRuteo(List<PickingPackingDTO> pickingDTO);

    }
}