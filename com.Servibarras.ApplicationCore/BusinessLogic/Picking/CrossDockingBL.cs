using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.Servibarras.ApplicationCore.BusinessLogic;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CrossDockingBL : ICrossDockingBL
    {
        private readonly ICrossDockingDAL _crossDockingDAL;
        private readonly IRuteoBL _ruteoBL;
        public CrossDockingBL(ICrossDockingDAL crossDockingDAL, IRuteoBL ruteoBL)
        {
            this._crossDockingDAL = crossDockingDAL;
            this._ruteoBL = ruteoBL;
        }
        public DataSet SetCrossDockingRuteoDetalle(JObject crossDockingParam)
        {
            var crossDockingAux = JsonConvert.DeserializeObject<CrossDockingDTO>(crossDockingParam.ToString());
            return this._crossDockingDAL.SetCrossDockingRuteoDetalle(crossDockingAux);
        }

        public DataSet GetFiltroBahiasProductosCrossDocking(JObject crossDockingParam)
        {
            DataSet dataResult = new DataSet();         
            var crossDockingAux = JsonConvert.DeserializeObject<FiltroBahiasProductosCrossDockingDTO>(crossDockingParam.ToString());
            if (crossDockingAux == null) return null;

            var data = this._ruteoBL.PackingDetalleUsuarioId(crossDockingAux.usuarioId);

            if (data == null)
                dataResult = this._crossDockingDAL.GetFiltroBahiasProductosCrossDocking(crossDockingAux);

            else
                dataResult = data;

            return dataResult;


        }

        public DataSet getPickingCrossDocking()
        {
            return this._crossDockingDAL.getPickingCrossDocking();
        }

        public DataSet GetCodigoUbicacionByUsuarioIdCrossDocking(JObject crossDockingParam)
        {
            DataSet dataResult = new DataSet();

            var crossDockingAux = JsonConvert.DeserializeObject<UbicacionCrossDockingDTO>(crossDockingParam.ToString());
            return this._crossDockingDAL.GetCodigoUbicacionByUsuarioIdCrossDocking(crossDockingAux);
        }
        public DataSet GetSaldoDetalleRuteoCrossDocking(JObject saldoDetalleRuteoCrossDockingParam)
        {
            var crossDockingAux = JsonConvert.DeserializeObject<SaldoDetalleRuteoCrossDockingDTO>(saldoDetalleRuteoCrossDockingParam.ToString());
            return this._crossDockingDAL.GetSaldoDetalleRuteoCrossDocking(crossDockingAux);
        }
       
    }
}
