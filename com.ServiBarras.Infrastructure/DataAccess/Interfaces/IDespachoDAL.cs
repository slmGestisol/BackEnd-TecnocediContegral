using System.Collections.Generic;
using System.Data;
using com.ServiBarras.Shared.ModelDTO;


namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IDespachoDAL
    {
        DataSet SPDespachoRuteo(DespachoDTO despachoDTO);
        DataSet GetDespachoDetalleByUbicacionCodigo(string ubicacionCodigo);
        DataSet GetDespachoArqueo(long ubicacionPuertaId);
        DataSet GetDespachoDetalleUbicacionDestino(long despachoDetalleId);
        DataSet ValidarDespachoCargaUsuario(long usuarioId);
        DataSet ValidarDespachoParcialCargaUsuario(long usuarioId);
        DataSet GetDespachobyUbicacionidpuerta(long ubicacionIdPuerta);
        DataSet GetPedidosDespachos(PedidosDespachoDTO pedidosDespachosAux);
        DataSet GetProductoDespachoReciente(PedidosDespachoDTO pedidosDespachosAux);
        DataSet SPDespachoPacialRuteo(List<DespachoParcialDTO> DespachoParcialDTO);
        DataSet setDespachoPickingPacking(DespachoPickingPackingDTO DespachoPickingPackingDTO);
        DataSet SPPedidosDespachoParcial(DespachoParcialPedidosDTO DespachoParcialPedidosDTO);
        DataSet SPCerrarDespachoBahiaRuteo(DespachoBahiaRuteoDTO despachoBahiaRuteoDTO);
        DataSet CancelarLineaDespachoParcial(DespachoParcialPedidosDTO despachoAux);
        DataSet DespachoLibreCrearDocumento(DespachoLibreCrearDocumento despachoLibreCrearDocumento);
        DataSet getDespachoLibrePuertas(bool parcial);
        DataSet getDespachoLibrePuertasDetalle(string documentoERP, bool parcial);
        DataSet getDespachoLibreInformacionDespacho(string documentoERP, long productoId);
        DataSet setDespachoLibreDocumentoProcesar(DespachoLibreProcesarDocumento parametrosDespachoLibreProcesarDocumento);
        DataSet setDespachoLibreDocumentoCerrar(DespachoLibreCerrarDocumento parametrosDespachoLibreCerrarDocumento);
        DataSet setDespachoLibreCambiarPuerta(DespachoLibreCambioPuerta parametrosDespachoLibreCambiarPuerta);
        DataSet getDespachoLotesPuerta(long ubicacionid, long productoId);
    }
}