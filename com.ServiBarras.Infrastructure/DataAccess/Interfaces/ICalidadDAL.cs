using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICalidadDAL
    {
        DataSet GetCalidadSaldosUbicaciones(long instalacionId);
        DataSet SetCalidadUbicaciones(CalidadDTO calidadAux);
    }
}