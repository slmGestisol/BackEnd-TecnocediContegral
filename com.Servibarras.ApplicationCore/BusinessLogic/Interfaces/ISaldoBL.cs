using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ISaldoBL
    {
        DataSet GetSaldoDetalleByUbicacionId(long ubicacionId);
        DataSet GetSaldoDetalleByUbicacionUbicacionCodigo(long ubicacionId, string ubicacionCodigo);
        DataSet SetSaldoReubicacion(JObject reubicacionJson);
        DataSet ValidarSaldoCargaUsuario(long usuarioId);
        DataSet GetUbicacionesProductoSugerida(JObject reubicacionJson);
        string SetAjustarSaldo(JArray parametrosAjusteSaldos);
        DataSet GetSaldoDetalleByContenedorCodigo(JObject parametrosConsultarContenedores);
        DataSet SetDescargaSaldoParcial(object parametrosaldoParcial);
        DataSet SetSaldoReubicacionBarcode(JObject parametrosReubicacion);
        DataSet ValidarSaldoUsuarioReubicacionBarcode(long usuarioId);
        DataSet setReubicacionSaldoParcial(string proceso, JArray parametrosReubicacionParcial);
        DataSet setDescomprometerUbicacion(JObject parametrosDescomprometerUbicacion);
        DataSet setReubicarEstiba(JObject parametrosReubicarEstiba);
        DataSet setLimpiarEstiba(JObject parametrosLimpiarEstiba);
        DataSet setAjustarEstiba(JObject parametrosAjustarEstiba);


    }
}