using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class MaquinaBL : IMaquinaBL
    {
        private readonly IMaquinaDAL _maquinaDAL;
        public MaquinaBL(IMaquinaDAL maquinaDAL)
        {
            this._maquinaDAL = maquinaDAL;
        }
        public async Task<List<Maquinas>> GetMaquinasAsync()
        {
            return await this._maquinaDAL.GetMaquinasAsync();
        }


        public DataSet AsignarMaquinaUsuario(JObject parametrosRuteo)
        {
            var maquinaAux = JsonConvert.DeserializeObject<MaquinaDTO>(parametrosRuteo.ToString());
            return this._maquinaDAL.AsignarMaquinaUsuario(maquinaAux);
        }

    }
}
