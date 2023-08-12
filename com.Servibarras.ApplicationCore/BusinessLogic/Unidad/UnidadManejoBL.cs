using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class UnidadManejoBL : IUnidadManejoBL
    {

        private readonly IUnidadManejoDAL _unidadManejoDAL;
        public UnidadManejoBL(IUnidadManejoDAL unidadManejoDAL)
        {
            this._unidadManejoDAL = unidadManejoDAL;
        }
        public async Task<IEnumerable<UnidadesManejo>> GetUnidadesManejoAsync()
        {
            return await this._unidadManejoDAL.GetUnidadesManejoAsync();
        }



        public async Task<UnidadesManejo> GetUnidadManejoAsync(long id)
        {
            return await this._unidadManejoDAL.GetUnidadManejoAsync(id);
        }




        public void AddUnidadManejo(JObject unidadManejo)
        {
            try
            {

                var unidadManejoAux = JsonConvert.DeserializeObject<UnidadManejoDTO>(unidadManejo.ToString());

                UnidadesManejo _unidadManejo = new UnidadesManejo();

                _unidadManejo.unidadManejoDescripcion = unidadManejoAux.unidadManejoDescripcion;
                _unidadManejo.unidadManejoCodigo = unidadManejoAux.unidadManejoCodigo;

                this._unidadManejoDAL.AddUnidadManejo(_unidadManejo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUnidadManejo(long id)
        {
            this._unidadManejoDAL.DeleteUnidadManejo(id);

        }

        public bool UnidadManejoExists(long id)
        {
            return this._unidadManejoDAL.UnidadManejoExists(id);
        }
    }
}
