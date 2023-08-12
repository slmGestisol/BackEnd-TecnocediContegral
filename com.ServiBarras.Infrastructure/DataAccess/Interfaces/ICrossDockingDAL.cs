using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICrossDockingDAL
    {
        DataSet GetFiltroBahiasProductosCrossDocking(FiltroBahiasProductosCrossDockingDTO crossDockingDTO);
        DataSet SetCrossDockingRuteoDetalle(CrossDockingDTO crossDockingDTO);
        DataSet getPickingCrossDocking();

        DataSet GetCodigoUbicacionByUsuarioIdCrossDocking(UbicacionCrossDockingDTO crossDockingAux);

        DataSet GetSaldoDetalleRuteoCrossDocking(SaldoDetalleRuteoCrossDockingDTO saldoDetalleRuteoCrossDockingDTO);
    }
}