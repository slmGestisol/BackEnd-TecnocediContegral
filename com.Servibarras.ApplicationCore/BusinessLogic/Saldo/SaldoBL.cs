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
    public class SaldoBL : ISaldoBL
    {

        private readonly ISaldoDAL _saldoDAL;
        public SaldoBL(ISaldoDAL saldoDAL)
        {
            this._saldoDAL = saldoDAL;
        }

        public DataSet GetSaldoDetalleByUbicacionId(long ubicacionId, long contenedorId)
        {
            return this._saldoDAL.GetSaldoDetalleByUbicacionId(ubicacionId, contenedorId);
        }


        public DataSet SetSaldoReubicacion(JObject reubicacionJson)
        {
            var saldoReubicacionAux = JsonConvert.DeserializeObject<SaldoReubicacionDTO>(reubicacionJson.ToString());
            return this._saldoDAL.SetSaldoReubicacion(saldoReubicacionAux);
        }
        public DataSet ValidarSaldoCargaUsuario(long usuarioId)
        {
            return this._saldoDAL.ValidarSaldoCargaUsuario(usuarioId);
        }


        public DataSet GetUbicacionesProductoSugerida(JObject reubicacionJson)
        {
            var saldoReubicacionAux = JsonConvert.DeserializeObject<UbicacionProductoDTO>(reubicacionJson.ToString());
            return this._saldoDAL.GetUbicacionesProductoSugerida(saldoReubicacionAux);
        }

        public string SetAjustarSaldo(JArray parametrosAjusteSaldos)
        {
            var saldoAux = JsonConvert.DeserializeObject<List<SaldoAjusteDTO>>(parametrosAjusteSaldos.ToString());
            if (saldoAux == null) return null;
            
            return this._saldoDAL.SetAjustarSaldo(saldoAux);
        }

        public DataSet GetSaldoDetalleByContenedorCodigo(JObject parametrosConsultarContenedores)
        {
            var consultarContenedoresAux = JsonConvert.DeserializeObject<ConsultarContenedoresDTO>(parametrosConsultarContenedores.ToString());
            return this._saldoDAL.GetSaldoDetalleByContenedorCodigo(consultarContenedoresAux);
        }

        public DataSet SetDescargaSaldoParcial(object parametrosaldoParcial)
        {
            var saldoAux = JsonConvert.DeserializeObject<DescargaSaldoDTO>(parametrosaldoParcial.ToString());
            if (saldoAux == null) return null;

            return this._saldoDAL.SetDescargaSaldoParcial(saldoAux);
        }

        public DataSet SetSaldoReubicacionBarcode(JObject parametrosReubicacion)
        {
            var saldoReubicacionAux = JsonConvert.DeserializeObject<SaldoReubicacionDTO>(parametrosReubicacion.ToString());
            return this._saldoDAL.SetSaldoReubicacionBarcode(saldoReubicacionAux);
        }



        public DataSet ValidarSaldoUsuarioReubicacionBarcode(long usuarioId)
        {
            return this._saldoDAL.ValidarSaldoUsuarioReubicacionBarcode(usuarioId);

        }

        public DataSet setReubicacionSaldoParcial(JArray parametrosReubicacionParcial)
        {
            var saldoReubicacionAux = JsonConvert.DeserializeObject<List<SaldoReubicacionParcialDTO>>(parametrosReubicacionParcial.ToString());
            DataSet data = new DataSet();
            foreach(var reubicacion in saldoReubicacionAux)
            {
                data= this._saldoDAL.setReubicacionSaldoParcial(reubicacion);
            }
            return data;

        }

        public DataSet setDescomprometerUbicacion(JObject parametrosDescomprometerUbicacion)
        {
            var saldoDescomprometerUbicacion = JsonConvert.DeserializeObject<SaldoDescomprometerUbicacionDTO>(parametrosDescomprometerUbicacion.ToString());
            return this._saldoDAL.setDescomprometerUbicacion(saldoDescomprometerUbicacion);
        }
        public DataSet setReubicarEstiba(JObject parametrosReubicarEstiba)
        {
            var parametrosReubicarEstibaAUX = JsonConvert.DeserializeObject<ReubicacionEstibaDTO>(parametrosReubicarEstiba.ToString());
            return this._saldoDAL.setReubicarEstiba(parametrosReubicarEstibaAUX);
        }

        public DataSet setLimpiarEstiba(JObject parametrosLimpiarEstiba)
        {
            var parametrosLimpiarEstibaAUX = JsonConvert.DeserializeObject<LimpiarEstibaDTO>(parametrosLimpiarEstiba.ToString());
            return this._saldoDAL.setLimpiarEstiba(parametrosLimpiarEstibaAUX);
        }
        public DataSet setAjustarEstiba(JObject parametrosAjustarEstiba)
        {
            var parametrosAjustarEstibaAUX = JsonConvert.DeserializeObject<AjustarEstibaDTO>(parametrosAjustarEstiba.ToString());
            return this._saldoDAL.setAjustarEstiba(parametrosAjustarEstibaAUX);
        }

        // public DataSet GetSaldoDetalleByContenedorCodigo(JObject parametrosConsultarContenedores)

    }
}
