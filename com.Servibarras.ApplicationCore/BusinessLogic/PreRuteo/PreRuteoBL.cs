using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PreRuteoBL : IPreRuteoBL
    {
        private readonly IPreRuteoDAL _preRuteoDAL;
        public PreRuteoBL(IPreRuteoDAL preRuteoDAL)
        {
            this._preRuteoDAL = preRuteoDAL;
        }
        public async Task<List<PreRuteos>> GetPreRuteoAsync(long preRuteoId)
        {
            return await this._preRuteoDAL.GetPreRuteoAsync(preRuteoId);
        }

        public DataSet GetPreRuteos()
        {
            return this._preRuteoDAL.GetPreRuteos();
        }

        public DataSet GetPreRuteoDetalle(long id)
        {
            return this._preRuteoDAL.GetPreRuteoDetalle(id);
        }

        public void AddPreRuteos(PreRuteos preRuteo)
        {
            this._preRuteoDAL.AddPreRuteos(preRuteo);
        }

        public void DeletePlantillasProducto(long plantillaProductoId)
        {



        }

        public bool PreRuteosIdExists(long preRuteoId)
        {
            return this._preRuteoDAL.PreRuteosIdExists(preRuteoId);
        }


        public DataSet SPProcessPreRuteo(JObject preRuteoJson)
        {

            var preRuteoAux = JsonConvert.DeserializeObject<PreRuteoDTO>(preRuteoJson.ToString());
            return this._preRuteoDAL.SPProcessPreRuteo(preRuteoAux);
        }


        public void AddPedidosPreRuteo(JArray pedidosPreRuteolist)
        {
            var pedidoPrereRuteoAux = JsonConvert.DeserializeObject<List<PedidosPreRuteoDTO>>(pedidosPreRuteolist.ToString());
            this._preRuteoDAL.AddPedidosPreRuteo(pedidoPrereRuteoAux);
        }

        public async Task<List<Pedidos>> GetPedidosPreRuteo(long preRuteoId)
        {
            return await this._preRuteoDAL.GetPedidosPreRuteo(preRuteoId);
        }

        public void CancelPreruteo(JObject parametrosCancelPreRuteo)
        {
            var PrereRuteoAux = JsonConvert.DeserializeObject<PreRuteoItemDTO>(parametrosCancelPreRuteo.ToString());
            this._preRuteoDAL.CancelPreruteo(PrereRuteoAux);
        }


        public DataSet GetPreRuteoNovedades(long preRuteoId)
        {           
            return this._preRuteoDAL.GetPreRuteoNovedades(preRuteoId);
        }       

        public DataSet SetPreruteoCrossDocking(JArray parametrosPreRuteo)
        {
            DataSet result = new DataSet();
            var PrereRuteoNovedadesAux = JsonConvert.DeserializeObject<List<PreRuteoNovedadesDTO>>(parametrosPreRuteo.ToString());

            foreach (var preruteoNovedad in PrereRuteoNovedadesAux)
            {
                result = this._preRuteoDAL.SetPreruteoCrossDocking(preruteoNovedad);
            }

            return result;

        }

        public DataSet GetPedidoSecuencial()
        {
            DataSet result = new DataSet();
            
                result = this._preRuteoDAL.GetPedidoSecuencial();
            
            return result;

        }

        public DataSet getPedidoOrdenConfiguracion(long preruteoId)
        {
            DataSet result = new DataSet();

            result = this._preRuteoDAL.getPedidoOrdenConfiguracion(preruteoId);

            return result;

        }


        public DataSet setPedidoConfiguracionOrden(JArray parametrosPedidosConfiguracionOrden)
        {
            DataSet result = new DataSet();
            var pedidosConfiguracionOrdenDTOAUX = JsonConvert.DeserializeObject<List<PedidosConfiguracionOrdenDTO>>(parametrosPedidosConfiguracionOrden.ToString());
            result = this._preRuteoDAL.setPedidoConfiguracionOrden(pedidosConfiguracionOrdenDTOAUX);
            return result;

        }

        public DataSet addpedidosDetalleCrossDocking(JArray parametrosPedidosDetalleCrossDocking)
        {
            DataSet result = new DataSet();
            var pedidoDetalleCrossDocking = JsonConvert.DeserializeObject<List<PedidosDetalleCrossDockingDTO>>(parametrosPedidosDetalleCrossDocking.ToString());
            return result =this._preRuteoDAL.addpedidosDetalleCrossDocking(pedidoDetalleCrossDocking);
        }

    }
}
