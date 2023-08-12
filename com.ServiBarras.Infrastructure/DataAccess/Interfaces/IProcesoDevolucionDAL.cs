using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProcesoDevolucionDAL
    {
        DataSet GetValidarProcesoDevolucionCargaUsuario(long usuarioId);
        DataSet GetSaldoDetalleUbicacionContenedorCodigo(SaldoUbicacionContenedorDTO saldoAux);
        DataSet SPProcesoDevolucion(ProcesoDevolucionDTO devolucionAux);
        DataSet GetDevolucionDespacho();
        DataSet SetComprometerSaldoDevolucion(SaldoDevolucionDTO saldoCompromiso);
        DataSet GetUbicacionesDespachoParcialDevolucion();
        DataSet GetPedidoDetalleDevolucion(DevolucionUbicacionPedidosDTO depachoCambio);
        DataSet GetContenedoresByContenedorCodigoDevolucion(DevolucionContenedoDTO devolucionAux);

        DataSet SetProcesarDevolucionTransaccion(DevolucionTransaccionDTO devolucionAux);

        DataSet ValidarDespachoCargaUsuarioDevolucion(long usuarioId);
        DataSet SetCancelarSaldoDevolucion(SaldoDevolucionDTO saldoCompromiso);


    }
}