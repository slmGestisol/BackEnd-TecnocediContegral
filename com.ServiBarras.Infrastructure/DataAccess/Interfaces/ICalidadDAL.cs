using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ICalidadDAL
    {
        DataSet GetCalidadSaldosUbicaciones();
        DataSet SetCalidadUbicaciones(CalidadDTO calidadAux);
    }
}