using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IRecepcionDAL
    {
        DataSet getRecepciones();

        DataSet getRecepcionesDetalle(long recepcionId);
        DataSet setProcesarRecepcion(recepcionProcesarDTO recepcionProcesarDTO);
        DataSet getRecepcionesContenedoresByContenedorCodigo(long recepcionId, string contenedorCodigo);
        DataSet getRecepcionValidacionUbicacion(string ubicacionCodigo,long instalacionId, long usuarioId);
        DataSet setCerrarRecepcion(recepcionCerrarDTO recepcionCerrarDTO);

    }
}