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
    public class ProcesoDevolucionBL : IProcesoDevolucionBL
    {
        private readonly IProcesoDevolucionDAL _devolucionDAL;

        public ProcesoDevolucionBL(IProcesoDevolucionDAL devolucionDAL)
        {
            this._devolucionDAL = devolucionDAL;
        }

        public DataSet GetValidarProcesoDevolucionCargaUsuario(long usuarioId)
        {
            return this._devolucionDAL.GetValidarProcesoDevolucionCargaUsuario(usuarioId);
        }

        public DataSet SPProcesoDevolucion(JArray procesoDevolucionJson)
        {
            DataSet result = new DataSet();
            var devolucionAux = JsonConvert.DeserializeObject<List<ProcesoDevolucionDTO>>(procesoDevolucionJson.ToString());

            var guidAux = Guid.NewGuid();


            foreach (var devolucion in devolucionAux)
            {
                devolucion.devolucionProcesoId = guidAux;
                result = this._devolucionDAL.SPProcesoDevolucion(devolucion);
            }

            return result;
        }

        public DataSet GetSaldoDetalleUbicacionContenedorCodigo(JObject parametrosSaldo)
        {
            var saldoAux = JsonConvert.DeserializeObject<SaldoUbicacionContenedorDTO>(parametrosSaldo.ToString());
            return this._devolucionDAL.GetSaldoDetalleUbicacionContenedorCodigo(saldoAux);
        }

        public DataSet GetDevolucionDespacho()
        {
            return this._devolucionDAL.GetDevolucionDespacho();
        }

        public DataSet SetComprometerSaldoDevolucion(JObject saldoDevolucion)
        {
            var devolucionAux = JsonConvert.DeserializeObject<SaldoDevolucionDTO>(saldoDevolucion.ToString());
            return this._devolucionDAL.SetComprometerSaldoDevolucion(devolucionAux);
        }

        public DataSet SetCancelarSaldoDevolucion(JObject saldoDevolucion)
        {
            var devolucionAux = JsonConvert.DeserializeObject<SaldoDevolucionDTO>(saldoDevolucion.ToString());
            return this._devolucionDAL.SetCancelarSaldoDevolucion(devolucionAux);
        }

        public DataSet GetUbicacionesDespachoParcialDevolucion()
        {
            return this._devolucionDAL.GetUbicacionesDespachoParcialDevolucion();
        }


        public DataSet GetPedidoDetalleDevolucion(JObject saldoDevolucion)
        {
            var devolucionAux = JsonConvert.DeserializeObject<DevolucionUbicacionPedidosDTO>(saldoDevolucion.ToString());
            return this._devolucionDAL.GetPedidoDetalleDevolucion(devolucionAux);
        }

        public DataSet GetContenedoresByContenedorCodigoDevolucion(JObject parametrosContenedor)
        {
            var devolucionAux = JsonConvert.DeserializeObject<DevolucionContenedoDTO>(parametrosContenedor.ToString());
            return this._devolucionDAL.GetContenedoresByContenedorCodigoDevolucion(devolucionAux);
        }

        public DataSet SetProcesarDevolucionTransaccion(JArray parametrosDevolucion)
        {
            DataSet result = new DataSet();
            var devolucionAux = JsonConvert.DeserializeObject<List<DevolucionTransaccionDTO>>(parametrosDevolucion.ToString());
            foreach (var devolucion in devolucionAux)
            {              
                result = this._devolucionDAL.SetProcesarDevolucionTransaccion(devolucion);
            }
            return result;       
        }

        public DataSet ValidarDespachoCargaUsuarioDevolucion(long usuarioId)
        {
            return this._devolucionDAL.ValidarDespachoCargaUsuarioDevolucion(usuarioId);
        }
    }
}
