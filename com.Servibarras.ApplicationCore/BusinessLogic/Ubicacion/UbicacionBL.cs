using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class UbicacionBL : IUbicacionBL
    {
        private readonly IUbicacionDAL _ubicacionDAL;
       
        public UbicacionBL(IUbicacionDAL ubicacionDAL)
        {
            this._ubicacionDAL = ubicacionDAL;
            
        }

        public async Task<List<Ubicaciones>> GetUbicacionesAsync()
        {
            return await this._ubicacionDAL.GetUbicacionesAsync();
        }
        /// <summary>
        /// Método que consulta una ubicacion según el ubicacionId
        /// </summary>
        /// <param name="ubicacionId"></param>
        /// <returns></returns>
        public async Task<Ubicaciones> GetUbicacionAsync(long ubicacionId)
        {
            return await this._ubicacionDAL.GetUbicacionAsync(ubicacionId);
        }
        public async Task<List<Ubicaciones>> GetUbicacionesByTipoUbicacionAsync(JObject FilterBahia)
        {
            
            var FilterBahiaAux = JsonConvert.DeserializeObject<FilterBahiaDTO>(FilterBahia.ToString());
            return await this._ubicacionDAL.GetUbicacionesByTipoUbicacionAsync(FilterBahiaAux);
        }
        public DataSet GetCodigoUbicacionByUsuarioId(long usuarioId)
        {
            return this._ubicacionDAL.GetCodigoUbicacionByUsuarioId(usuarioId);
        }
        public DataSet GetCodigoReubicacionByUsuarioId(long usuarioId)
        {
            return this._ubicacionDAL.GetCodigoReubicacionByUsuarioId(usuarioId);
        }
        public string GetCodigoUbicacionPuertaByBahiaId(long bahiaId)
        {
            return this._ubicacionDAL.GetCodigoUbicacionPuertaByBahiaId(bahiaId);
        }
        public string GetCodigoUbicacionByBahiaPadreId(JObject parametrosUbicacion)
        {
            var despachoAux = JsonConvert.DeserializeObject<UbicacionDTO>(parametrosUbicacion.ToString());
            return this._ubicacionDAL.GetCodigoUbicacionByBahiaPadreId(despachoAux);
        }
        public DataSet getruteoDetalleUbicacionCapturada(JObject parametrosUbicacion)
        {
            var ubicacionAux = JsonConvert.DeserializeObject<UbicacionValidacionDTO>(parametrosUbicacion.ToString());
            return this._ubicacionDAL.getruteoDetalleUbicacionCapturada(ubicacionAux.ubicacionRequerida, ubicacionAux.ubicacionCapturada);
        }

        public DataSet getPuertasUbicaciones(long instalacionId)
        {
            return this._ubicacionDAL.getPuertasUbicaciones(instalacionId);
        }

        public DataSet GetContenedoresByUbicacionesCodigo(string ubicacionCodigo)
        {
            return this._ubicacionDAL.GetContenedoresByUbicacionesCodigo(ubicacionCodigo);
        }

      

        public DataSet GetUbicacionByUbicacionCodigo(string ubicacionCodigo)
        {
            return this._ubicacionDAL.GetUbicacionByUbicacionCodigo(ubicacionCodigo);
        }

        public DataSet GetDespachoParcialUbicaciones(long instalacionId)
        {
            return this._ubicacionDAL.GetDespachoParcialUbicaciones(instalacionId);
        }

        public DataSet GetBahiasDisponiblesByBahiaPadre(JObject parametrosUbicacion)
        {
            var ubicacionAux = JsonConvert.DeserializeObject<UbicacionContingenciaDTO>(parametrosUbicacion.ToString());
            return this._ubicacionDAL.GetBahiasDisponiblesByBahiaPadre(ubicacionAux);
        }

        public DataSet GetUbicacionByUbicacionCodigoBarcode(string ubicacionCodigo)
        {
            return this._ubicacionDAL.GetUbicacionByUbicacionCodigoBarcode(ubicacionCodigo);
        }
    }
}
