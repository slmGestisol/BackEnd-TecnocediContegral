using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class OrdenEmpaqueBL : IOrdenEmpaqueBL
    {
        private readonly IOrdenEmpaqueDAL _ordenEmpaqueDAL;
        public OrdenEmpaqueBL(IOrdenEmpaqueDAL ordenEmpaqueDAL)
        {
            this._ordenEmpaqueDAL = ordenEmpaqueDAL;
        }
        public DataSet OrdenEmpaqueCambiarUbicacion(JObject parametrosOrdenJson)
        {
            var ordenAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrdenJson.ToString());
            return this._ordenEmpaqueDAL.OrdenEmpaqueCambiarUbicacion(ordenAux);
        }

        public DataSet OrdenEmpaqueCierreUbicacionEstiba(JObject parametrosOrdenJson)
        {
            var ordenAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrdenJson.ToString());
            return this._ordenEmpaqueDAL.OrdenEmpaqueCierreUbicacionEstiba(ordenAux);
        }

       public DataSet OrdenEmpaqueEstacionTrabajoUsuario(JObject parametrosOrdenJson)
        {
            var ordenAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrdenJson.ToString());
            return this._ordenEmpaqueDAL.OrdenEmpaqueEstacionTrabajoUsuario(ordenAux);

        }

        public DataSet OrdenEmpaqueEliminarContenedor(JObject parametrosOrden)
        {
            var ordenAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrden.ToString());
            return this._ordenEmpaqueDAL.OrdenEmpaqueEliminarContenedor(ordenAux);
        }

        public DataSet ValidarOdenEmpaqueSaldoUbicacion(JObject parametrosOrden)
        {
            var ordenAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrden.ToString());
            return this._ordenEmpaqueDAL.ValidarOdenEmpaqueSaldoUbicacion(ordenAux);

        }

        public DataSet OrdenEmpaqueContenedorByContenedorCodigo(JObject parametrosContenedor)
        {
            var contenedorAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosContenedor.ToString());
            return this._ordenEmpaqueDAL.OrdenEmpaqueContenedorByContenedorCodigo(contenedorAux);
        }

        public DataSet OrdenEmpaqueContenedorUbicacion(JObject parametrosOrdenEmpaque)
        {
            var ordenEmpaqueAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrdenEmpaque.ToString());
            return this._ordenEmpaqueDAL.OrdenEmpaqueContenedorUbicacion(ordenEmpaqueAux);
        }

        public DataSet SetSiesaPlanoInventario(JObject parametrosOrden)
        {
            var ordenAux = JsonConvert.DeserializeObject<OrdenEmpaqueDTO>(parametrosOrden.ToString());
            return this._ordenEmpaqueDAL.SetSiesaPlanoInventario(ordenAux);

        }

        public DataSet getOrdenesEmpaque()
        {
            return this._ordenEmpaqueDAL.getOrdenesEmpaque();

        }

        public DataSet setGenerarOrdenEmpaque(JObject parametrosOrden)
        {
            var ordenAux = JsonConvert.DeserializeObject<generarOrdenEmpaqueDTO>(parametrosOrden.ToString());
            return this._ordenEmpaqueDAL.setGenerarOrdenEmpaque(ordenAux);

        }
        public DataSet setActivarOrdenEmpaque(long ordenEmpaqueId)
        {
            return this._ordenEmpaqueDAL.setActivarOrdenEmpaque(ordenEmpaqueId);

        }
        public string setCerrarOrdenEmpaque(long ordenEmpaqueId)
        {
            return this._ordenEmpaqueDAL.setCerrarOrdenEmpaque(ordenEmpaqueId);

        }
        public DataSet setOrdenEmpaqueFechaLote(JObject parametrosFechaLote)
        {
            var ordenAux = JsonConvert.DeserializeObject<cambioFechaLoteOrdenEmpaqueDTO>(parametrosFechaLote.ToString());
            return this._ordenEmpaqueDAL.setOrdenEmpaqueFechaLote(ordenAux);

        }

        public DataSet getEstacionLoteByEstacionId(long estacionId)
        {
            return this._ordenEmpaqueDAL.getEstacionLoteByEstacionId(estacionId);

        }

        public DataSet setEstacionLoteCambiarEstado(JObject parametrosCambioEstado)
        {
            var ordenAux = JsonConvert.DeserializeObject<cambioEstadioEstacionLoteDTO>(parametrosCambioEstado.ToString());
            return this._ordenEmpaqueDAL.setEstacionLoteCambiarEstado(ordenAux);

        }
        public DataSet setCerrarEstibaRecepcion(JObject parametrosCerrarRecepcion)
        {
            var ordenAux = JsonConvert.DeserializeObject<cerrarRecpcecionDTO>(parametrosCerrarRecepcion.ToString());
            return this._ordenEmpaqueDAL.setCerrarEstibaRecepcion(ordenAux);

        }
        public DataSet getOrdenesExternas(string documento)
        {
            return this._ordenEmpaqueDAL.getOrdenesExternas(documento);

        }
        public DataSet setGenerarOrdenEmpaqueExterna(JObject parametrosOrden)
        {
            var ordenAux = JsonConvert.DeserializeObject<generarOrdenEmpaqueExternaDTO>(parametrosOrden.ToString());
            return this._ordenEmpaqueDAL.setGenerarOrdenEmpaqueExterna(ordenAux);

        }
        public DataSet getValidarLoteExterno(string documento,long productoId, string LoteCodigo)
        {
            return this._ordenEmpaqueDAL.getValidarLoteExterno(documento, productoId, LoteCodigo);

        }
        public DataSet getCiaExternos()
        {
            return this._ordenEmpaqueDAL.getCiaExternos();
        }
        public DataSet setCerrarEstibaRecepcionCalidad(JObject parametrosRecepcionCalidad)
        {
            var parametrosRecepcionCalidadAUX = JsonConvert.DeserializeObject<cerrarEstibaRecepcionCalidadDTO>(parametrosRecepcionCalidad.ToString());
            return this._ordenEmpaqueDAL.setCerrarEstibaRecepcionCalidad(parametrosRecepcionCalidadAUX);

        }
        public DataSet getTXOrdenEmpaqueById(long ordenEmpaqueId)
        {
            return this._ordenEmpaqueDAL.getTXOrdenEmpaqueById(ordenEmpaqueId);
        }
        public DataSet setImprimirOrdenEmpaqueById(long txOrdenEmpaqueId)
        {
            return this._ordenEmpaqueDAL.setImprimirOrdenEmpaqueById(txOrdenEmpaqueId);

        }
    }
}
