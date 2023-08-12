using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProcesoDevolucionBL
    {
        DataSet GetValidarProcesoDevolucionCargaUsuario(long usuarioId);
        DataSet SPProcesoDevolucion(JArray procesoDevolucionJson);
        DataSet GetSaldoDetalleUbicacionContenedorCodigo(JObject parametrosSaldo);
        DataSet GetDevolucionDespacho();
        DataSet SetComprometerSaldoDevolucion(JObject saldoDevolucion);
        DataSet SetCancelarSaldoDevolucion(JObject saldoDevolucion);
        DataSet GetUbicacionesDespachoParcialDevolucion();
        DataSet GetPedidoDetalleDevolucion(JObject saldoDevolucion);

        DataSet GetContenedoresByContenedorCodigoDevolucion(JObject parametrosContenedor);

        DataSet SetProcesarDevolucionTransaccion(JArray parametrosDevolucion);

        DataSet ValidarDespachoCargaUsuarioDevolucion(long usuarioId);
    }
}