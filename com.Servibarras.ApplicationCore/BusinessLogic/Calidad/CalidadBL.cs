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
    public class CalidadBL : ICalidadBL
    {

        private readonly ICalidadDAL _despachoDAL;
        public CalidadBL(ICalidadDAL despachoDAL)
        {
            this._despachoDAL = despachoDAL;
        }

        public DataSet GetCalidadSaldosUbicaciones()
        {
            
            return this._despachoDAL.GetCalidadSaldosUbicaciones();
        }

        public DataSet SetCalidadUbicaciones(JObject parametrosCalidad)
        {
            var calidadAux = JsonConvert.DeserializeObject<CalidadDTO>(parametrosCalidad.ToString());
          
            return this._despachoDAL.SetCalidadUbicaciones(calidadAux);
        }
    }
}
