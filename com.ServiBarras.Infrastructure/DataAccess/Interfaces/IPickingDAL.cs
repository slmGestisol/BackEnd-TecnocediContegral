using System.Collections.Generic;
using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPickingDAL
    {
        DataSet SPPickingRuteo(PickingDTO pickingDTO);
        DataSet SetPickingPackingRuteo(List<PickingPackingDTO> pickingDTO);

        DataSet getPickingPackingByRuteo(long ruteoId,long ruteoDetalleId);
        DataSet SetPickingPackingRuteoNovedad(List<PickingPackingNovedadDTO> PickingPackingNovedadDTO);
    }
}