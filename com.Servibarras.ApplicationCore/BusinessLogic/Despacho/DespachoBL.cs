using System;
using System.Collections.Generic;
using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class DespachoBL : IDespachoBL
    {
        private readonly IDespachoDAL _despachoDAL;

        public DespachoBL(IDespachoDAL despachoDAL)
        {
            this._despachoDAL = despachoDAL;
        }

        public DataSet SPDespachoRuteo(JObject despachoJson)
        {
            var despachoAux = JsonConvert.DeserializeObject<DespachoDTO>(despachoJson.ToString());
            return this._despachoDAL.SPDespachoRuteo(despachoAux);
        }

        public DataSet SPDespachoPacialRuteo(JArray DespachoParcialDTO)
        {
            var despachoAux = JsonConvert.DeserializeObject<List<DespachoParcialDTO>>(DespachoParcialDTO.ToString());
            DataSet data = new DataSet();

            data = this._despachoDAL.SPDespachoPacialRuteo(despachoAux);
            
            return data;
        }

        public DataSet setDespachoPickingPacking(JObject DespachoPickingPackingDTO)
        {
            var despachoAux = JsonConvert.DeserializeObject<DespachoPickingPackingDTO>(DespachoPickingPackingDTO.ToString());

            return this._despachoDAL.setDespachoPickingPacking(despachoAux);
        }

        public DataSet GetDespachoDetalleByUbicacionCodigo(string ubicacionCodigo)
        {
            return this._despachoDAL.GetDespachoDetalleByUbicacionCodigo(ubicacionCodigo);
        }
        public DataSet GetDespachoDetalleUbicacionDestino(long despachoDetalleId)
        {
            return this._despachoDAL.GetDespachoDetalleUbicacionDestino(despachoDetalleId);
        }

        public DataSet GetDespachoArqueo(long ubicacionPuertaId)
        {
            return this._despachoDAL.GetDespachoArqueo(ubicacionPuertaId);
        }

        public DataSet SPPedidosDespachoParcial(JObject DespachoParcialPedidosDTO)
        {
            var despachoAux = JsonConvert.DeserializeObject<DespachoParcialPedidosDTO>(DespachoParcialPedidosDTO.ToString());
            return this._despachoDAL.SPPedidosDespachoParcial(despachoAux);
        }

        public DataSet ValidarDespachoParcialCargaUsuario(long usuarioId)
        {
            return this._despachoDAL.ValidarDespachoParcialCargaUsuario(usuarioId);
        }

        public DataSet ValidarDespachoCargaUsuario(long usuarioId)
        {
            return this._despachoDAL.ValidarDespachoCargaUsuario(usuarioId);
        }

        public DataSet GetPedidosDespachos(JObject parametrosPedidosDespachos)
        {
            var pedidosDespachosAux = JsonConvert.DeserializeObject<PedidosDespachoDTO>(parametrosPedidosDespachos.ToString());
            return this._despachoDAL.GetPedidosDespachos(pedidosDespachosAux);
        }

        public DataSet GetProductoDespachoReciente(JObject parametrosProductoDespachos)
        {
            var pedidosDespachosAux = JsonConvert.DeserializeObject<PedidosDespachoDTO>(parametrosProductoDespachos.ToString());
            return this._despachoDAL.GetProductoDespachoReciente(pedidosDespachosAux);
        }

        public DataSet GetDespachobyUbicacionidpuerta(long ubicacionIdPuerta)
        {
            return this._despachoDAL.GetDespachobyUbicacionidpuerta(ubicacionIdPuerta);
        }

        public DataSet SPCerrarDespachoBahiaRuteo(JObject parametrosDespachoBahiaRuteo)
        {
            var despachoBahiaRuteoAux = JsonConvert.DeserializeObject<DespachoBahiaRuteoDTO>(parametrosDespachoBahiaRuteo.ToString());
            return this._despachoDAL.SPCerrarDespachoBahiaRuteo(despachoBahiaRuteoAux);


        }


        public DataSet CancelarLineaDespachoParcial(JObject parametrosPedidosdespachoParcial)
        {
            var despachoAux = JsonConvert.DeserializeObject<DespachoParcialPedidosDTO>(parametrosPedidosdespachoParcial.ToString());
            return this._despachoDAL.CancelarLineaDespachoParcial(despachoAux);

        }

        public DataSet DespachoLibreCrearDocumento(JObject parametrosDespachoLibreCrearDocumento)
        {
            var despachoCrearDocAux = JsonConvert.DeserializeObject<DespachoLibreCrearDocumento>(parametrosDespachoLibreCrearDocumento.ToString());
            return this._despachoDAL.DespachoLibreCrearDocumento(despachoCrearDocAux);

        }
        public DataSet getDespachoLibrePuertas(bool parcial)
        {
            return this._despachoDAL.getDespachoLibrePuertas(parcial);
        }

        public DataSet getDespachoLibrePuertasDetalle(string documentoERP, bool parcial)
        {
            return this._despachoDAL.getDespachoLibrePuertasDetalle(documentoERP, parcial);
        }
        public DataSet getDespachoLibreInformacionDespacho(string documentoERP,long productoId)
        {
            return this._despachoDAL.getDespachoLibreInformacionDespacho(documentoERP, productoId);
        }

        public DataSet setDespachoLibreDocumentoProcesar(JObject parametrosDespachoLibreProcesarDocumento)
        {
            var despachoProceDocAux = JsonConvert.DeserializeObject<DespachoLibreProcesarDocumento>(parametrosDespachoLibreProcesarDocumento.ToString());
            return this._despachoDAL.setDespachoLibreDocumentoProcesar(despachoProceDocAux);

        }
        public DataSet setDespachoLibreDocumentoCerrar(JObject parametrosDespachoLibreCerrarDocumento)
        {
            var despachoCerrarDocAux = JsonConvert.DeserializeObject<DespachoLibreCerrarDocumento>(parametrosDespachoLibreCerrarDocumento.ToString());
            return this._despachoDAL.setDespachoLibreDocumentoCerrar(despachoCerrarDocAux);

        }
        public DataSet setDespachoLibreCambiarPuerta(JObject parametrosDespachoLibreCambiarPuerta)
        {
            var despachoCambioPuertaDocAux = JsonConvert.DeserializeObject<DespachoLibreCambioPuerta>(parametrosDespachoLibreCambiarPuerta.ToString());
            return this._despachoDAL.setDespachoLibreCambiarPuerta(despachoCambioPuertaDocAux);

        }
        public DataSet getDespachoLotesPuerta(long ubicacionId, long productoId)
        {
            return this._despachoDAL.getDespachoLotesPuerta(ubicacionId,productoId);

        }
    }
}
