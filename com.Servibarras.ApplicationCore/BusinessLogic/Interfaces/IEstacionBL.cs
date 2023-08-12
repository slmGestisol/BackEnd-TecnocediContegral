using System.Data;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IEstacionBL
    {
        DataSet GetEstaciones(string tipoEstacionCodigo);
        DataSet GetUbicacionesByEstacionId(long estacionId);
    }
}