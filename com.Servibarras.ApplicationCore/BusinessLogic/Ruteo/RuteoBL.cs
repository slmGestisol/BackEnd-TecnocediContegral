using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class RuteoBL : IRuteoBL
    {

        private readonly IRuteoDAL _ruteoDAL;
        private readonly IPackingDAL _packingDAL;
        public RuteoBL(IRuteoDAL ruteoDAL, IPackingDAL packingDAL)
        {
            this._ruteoDAL = ruteoDAL;
            this._packingDAL = packingDAL;
        }

        public async Task<List<Ruteos>> GetRuteosAsync()
        {
            return await this._ruteoDAL.GetRuteosAsync();
        }

        public DataSet GetRuteosByInstalacionIdAsync(long instalacionId)
        {
            return  this._ruteoDAL.GetRuteosByInstalacionIdAsync(instalacionId);
        }


        public async Task<Ruteos> GetRuteosAsync(long preRuteoId)
        {
            return await this._ruteoDAL.GetRuteoAsync(preRuteoId);
        }

        public DataSet GetRuteoDetalle(JObject parametrosRuteo)
        {
            var responseText = Regex.Replace(parametrosRuteo.ToString(), "[\t|\r\n]", "");
            if (responseText.IndexOf("response\": [") != -1)
            {
                int start = responseText.IndexOf('[') + 1;
                int end = responseText.IndexOf(',', start);
                responseText = responseText.Substring(0, start) + responseText.Substring(end + 1);
            }
            var dataSet = new DataSet();
            var ruteoAux = JsonConvert.DeserializeObject<RuteoDetalleDTO>(responseText);
            return this._ruteoDAL.GetRuteoDetalle(ruteoAux.ruteoId, ruteoAux.ruteoDetalleId);
        }


        public DataSet GetRuteoDetalleFilters(JObject parametrosRuteo)
        {
            DataSet dataResult = new DataSet();

            var ruteoAux = JsonConvert.DeserializeObject<RuteoDetalleDTO>(parametrosRuteo.ToString());
            if (ruteoAux == null) return null;

            var data = PackingDetalleUsuarioId(ruteoAux.usuarioId);

            if (data == null)
                dataResult = this._ruteoDAL.GetRuteoDetalleFilters(ruteoAux);

            else
                dataResult = data;

            return dataResult;
        }

        public  DataSet PackingDetalleUsuarioId(long? usuarioId)
        {
            DataSet data = new DataSet();
            return this._packingDAL.PackingDetalleUsuarioId(usuarioId);
        }

        public DataSet GetRuteosPedidosProductosbyRuteoId(long ruteoId)
        {
            return this._ruteoDAL.GetRuteosPedidosProductosbyRuteoId(ruteoId);

        }
        public DataSet GetRuteosPedidosBahiasbyRuteoId(long ruteoId)
        {
            return this._ruteoDAL.GetRuteosPedidosBahiasbyRuteoId(ruteoId);
        }

        public DataSet SP_Add_Ruteo(JObject ruteoJson)
        {
            var responseText = Regex.Replace(ruteoJson.ToString(), "[\t|\r\n]", "");
            if (responseText.IndexOf("response\": [") != -1)
            {
                int start = responseText.IndexOf('[') + 1;
                int end = responseText.IndexOf(',', start);
                responseText = responseText.Substring(0, start) + responseText.Substring(end + 1);
            }

            var dataSet = new DataSet();
            var ruteoAux = JsonConvert.DeserializeObject<RuteoDTO>(responseText);


            // Aqui va el llamado a la validacion de placa
            string resultadoValidacion = this._ruteoDAL.SP_GET_ValidacionPlacaBahia(ruteoAux.placa, ruteoAux.pedidosOrdenBahiaInfo[0].pedidoUbicacionBahiaId);
            if (!string.IsNullOrWhiteSpace(resultadoValidacion))
            {
                // Si hay un mensaje de error, lo convertimos en un DataSet con mensaje de error y devolvemos
                var errorTable = new DataTable("Error");
                errorTable.Columns.Add("Error", typeof(string));
                errorTable.Rows.Add(resultadoValidacion);

                var errorDataSet = new DataSet();
                errorDataSet.Tables.Add(errorTable);
                return errorDataSet;
            }

            Console.WriteLine(ruteoAux.confirmacionesPlaca);


            dataSet = this._ruteoDAL.SP_Add_Ruteo(ruteoAux.preRuteoId, ruteoAux.usuarioId, ruteoAux.placa);
            
            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0)
                {
                    long ruteoId = (long)dataSet.Tables[0].Rows[0].ItemArray[0];
                    this._ruteoDAL.SP_Update_RuteoPedidosOrdenBahias(ruteoId, ruteoAux.pedidosOrdenBahiaInfo);
                    this._ruteoDAL.SP_Update_RuteoGrupos(ruteoId, ruteoAux.ruteosGrupos);
                    this._ruteoDAL.SP_Insert_PlacaConfirmaciones(ruteoId, ruteoAux.placa, ruteoAux.usuarioId, ruteoAux.confirmacionesPlaca);
                    this._ruteoDAL.AddRuteosPedidosDetalleEstado(ruteoId);

                    Console.WriteLine(ruteoAux.confirmacionesPlaca);
                    // dataSet = ruteoDAL.SP_Add_RuteoDetalle(ruteoId, ruteoAux.usuarioId);
                }

            }

            return dataSet;

        }


        public async Task<RuteosDetalle> GetRuteosDetalleItemAsync(long ruteoDetalleId)
        {
            return await this._ruteoDAL.GetRuteosDetalleItemAsync(ruteoDetalleId);
        }

        public DataSet SP_Add_NovedadRuteo(JObject parametrosRuteo)
        {
            var responseText = Regex.Replace(parametrosRuteo.ToString(), "[\t|\r\n]", "");
            if (responseText.IndexOf("response\": [") != -1)
            {
                int start = responseText.IndexOf('[') + 1;
                int end = responseText.IndexOf(',', start);
                responseText = responseText.Substring(0, start) + responseText.Substring(end + 1);
            }

            var novedadRuteoAux = JsonConvert.DeserializeObject<NovedadRuteoDTO>(responseText);
            return this._ruteoDAL.SP_Add_NovedadRuteo(novedadRuteoAux.novedadId, novedadRuteoAux.ruteoId, novedadRuteoAux.ruteoDetalleId, novedadRuteoAux.usuarioId);
        }

        public DataSet GetAsignacionBahiasRuteoId(int ruteoId)
        {
            return this._ruteoDAL.GetAsignacionBahiasRuteoId(ruteoId);
        }

        public DataSet GetFiltroBahiasProductosRuteo(JObject parametrosRuteo)
        {
            var ruteoAux = JsonConvert.DeserializeObject<RuteoBahiaProductoFilterDTO>(parametrosRuteo.ToString());
            if (ruteoAux == null) return null;

            return this._ruteoDAL.GetFiltroBahiasProductosRuteo(ruteoAux);

        }

        public DataSet GetRuteoPedidosInfo(long ruteoId)
        {
            return this._ruteoDAL.GetRuteoPedidosInfo(ruteoId);
        }
    }
}
