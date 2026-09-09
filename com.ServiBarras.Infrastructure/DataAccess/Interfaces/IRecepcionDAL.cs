using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IRecepcionDAL
    {
        DataSet getRecepciones();

        DataSet getRecepcionesDetalle(long recepcionId);
        DataSet setProcesarRecepcion(recepcionProcesarDTO recepcionProcesarDTO);
        DataSet getRecepcionesContenedoresByContenedorCodigo(long recepcionId, string contenedorCodigo, bool contenedoresAsociados);
        DataSet getRecepcionValidacionUbicacion(string ubicacionCodigo,long instalacionId, long usuarioId);
        DataSet getRecepcionSerialesValidacionUbicacion(string ubicacionCodigo,long instalacionId, long usuarioId);
        DataSet setCerrarRecepcion(recepcionCerrarDTO recepcionCerrarDTO);
        DataSet setProcesarCierreUbicacion(ProcesarCerrarUbicacionDTO CerrarUbicacionDTO);
        DataSet setRecepcionEliminarContenenedor(EliminarContenedorRecepcionDTO contenedorEliminar);

    }
}