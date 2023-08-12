using System.Collections.Generic;
using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ISaldoDAL
    {
        DataSet GetSaldoDetalleByUbicacionId(long ubicacionId, long contenedorId);
        DataSet SetSaldoReubicacion(SaldoReubicacionDTO saldoReubicacionAux);
        DataSet ValidarSaldoCargaUsuario(long usuarioId);
        DataSet GetUbicacionesProductoSugerida(UbicacionProductoDTO ubicacionProductoDTO);
        string SetAjustarSaldo(List<SaldoAjusteDTO> saldoDestalleAux);
        DataSet GetSaldoDetalleByContenedorCodigo(ConsultarContenedoresDTO ConsultarContenedoresDTO);
        DataSet SetDescargaSaldoParcial(DescargaSaldoDTO saldoAux);
        DataSet ValidarSaldoUsuarioReubicacionBarcode(long usuarioId);
        DataSet SetSaldoReubicacionBarcode(SaldoReubicacionDTO saldoReubicacionAux);
        DataSet setReubicacionSaldoParcial(SaldoReubicacionParcialDTO parametrosReubicacionParcial);
        DataSet setDescomprometerUbicacion(SaldoDescomprometerUbicacionDTO saldoDescomprometerUbicacion);
        DataSet setReubicarEstiba(ReubicacionEstibaDTO reubicacionEstibaDTO);
        DataSet setLimpiarEstiba(LimpiarEstibaDTO limpiarEstibaDTO);
        DataSet setAjustarEstiba(AjustarEstibaDTO parametrosAjustarEstiba);
    }
}