using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
   public interface IDespachoBL
    {
        DataSet SPDespachoRuteo(JObject despachoJson);
        DataSet GetDespachoDetalleByUbicacionCodigo(string ubicacionCodigo);
        DataSet GetDespachoArqueo(long ubicacionPuertaId);
        DataSet GetDespachoDetalleUbicacionDestino(long despachoDetalleId);
        DataSet ValidarDespachoCargaUsuario(long usuarioId);

        DataSet GetDespachobyUbicacionidpuerta(long ubicacionIdPuerta);
        DataSet GetPedidosDespachos(JObject parametrosPedidosDespachos);
        DataSet GetProductoDespachoReciente(JObject parametrosPedidosDespachos);
        DataSet SPPedidosDespachoParcial(JObject DespachoParcialPedidosDTO);
        DataSet SPDespachoPacialRuteo(JArray DespachoParcialDTO);

        DataSet SPCerrarDespachoBahiaRuteo(JObject parametrosDespachoBahiaRuteo);
        DataSet ValidarDespachoParcialCargaUsuario(long usuarioId);

        DataSet CancelarLineaDespachoParcial(JObject parametrosPedidosdespachoParcial);
        DataSet setDespachoPickingPacking(JObject DespachoParcialDTO);
        DataSet DespachoLibreCrearDocumento(JObject parametrosDespachoLibreCrearDocumento);
        DataSet getDespachoLibrePuertas(bool parcial);
        DataSet getDespachoLibrePuertasDetalle(string documentoERP, bool parcial);
        DataSet getDespachoLibreInformacionDespacho(string documentoERP, long productoId);
        DataSet setDespachoLibreDocumentoProcesar(JObject parametrosDespachoLibreProcesarDocumento);
        DataSet setDespachoLibreDocumentoCerrar(JObject parametrosDespachoLibreCerrarDocumento);
        DataSet setDespachoLibreCambiarPuerta(JObject parametrosDespachoLibreCambiarPuerta);
        DataSet getDespachoLotesPuerta(long ubicacionid, long productoId);
    }
}