using System.Data;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IEstacionDAL
    {
        DataSet GetEstaciones(string tipoEstacionCodigo);
        DataSet GetUbicacionesByEstacionId(long estacionId);
    }
}