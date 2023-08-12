using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;


namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class TipoAtributoBL : ITipoAtributoBL
    {
        private readonly ITipoAtributoDAL _tipoAtributoDAL;
        public TipoAtributoBL(ITipoAtributoDAL tipoAtributoDAL)
        {
            this._tipoAtributoDAL = tipoAtributoDAL;
        }

        public async Task<List<TiposAtributos>> GetTiposAtributosAsync()
        {
           
            return await this._tipoAtributoDAL.GetTiposAtributosAsync();

        }



        public async Task<TiposAtributos> GetTipoAtributoAsync(long tipoAtributoId)
        {
           
            return await this._tipoAtributoDAL.GetTipoAtributoAsync(tipoAtributoId);
        }



        public void AddTipoAtributo(TiposAtributos tipoAtributo)
        {

            this._tipoAtributoDAL.AddTipoAtributo(tipoAtributo);

        }

        public void DeleteTipoAtributo(long tipoAtributoId)
        {


        }

        public bool TipoAtributoExists(long tipoAtributoId)
        {
           
            return this._tipoAtributoDAL.TipoAtributoExists(tipoAtributoId);
        }
    }
}
