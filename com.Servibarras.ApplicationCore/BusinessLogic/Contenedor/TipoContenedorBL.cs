using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class TipoContenedorBL : ITipoContenedorBL
    {
        private readonly ITipoContenedorDAL _tipoContenedorDAL;
        public TipoContenedorBL(ITipoContenedorDAL tipoContenedorDAL)
        {
            this._tipoContenedorDAL = tipoContenedorDAL;
        }

        public async Task<List<TiposContenedores>> GetTiposContenedoresAsync()
        {
            return await this._tipoContenedorDAL.GetTiposContenedoresAsync();
        }



        public async Task<TiposContenedores> GetTipoContenedorAsync(long tipoContenedorId)
        {
            return await this._tipoContenedorDAL.GetTipoContenedorAsync(tipoContenedorId);
        }



        public void AddTipoContenedor(TiposContenedores tipoContenedor)
        {
            this._tipoContenedorDAL.AddTipoContenedor(tipoContenedor);

        }

        public void DeleteTipoContenedor(long tipoContenedorId)
        {


        }

        public bool TipoContenedorExists(long tipoContenedorId)
        {
            return this._tipoContenedorDAL.TipoContenedorExists(tipoContenedorId);
        }
    }
}