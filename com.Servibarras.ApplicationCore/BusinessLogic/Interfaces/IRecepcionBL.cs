using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IRecepcionBL
    {
        DataSet getRecepciones();
        DataSet getRecepcionesDetalle(long recepcionId);
        DataSet setProcesarRecepcion(JObject recepcionProcesarDTO);
        DataSet getRecepcionesContenedoresByContenedorCodigo(long recepcionId, string contenedorCodigo, bool contenedoresAsociados);
        DataSet getRecepcionValidacionUbicacion(string ubicacionCodigo, long instalacionId, long usuarioId);
        DataSet getRecepcionSerialesValidacionUbicacion(string ubicacionCodigo, long instalacionId, long usuarioId);
        DataSet setCerrarRecepcion(JObject recepcionCerrarDTO);
        DataSet setProcesarCierreUbicacion(JObject CerrarUbicacionDTO);
        DataSet setRecepcionEliminarContenenedor(JObject contenedorEliminar);
    }
}