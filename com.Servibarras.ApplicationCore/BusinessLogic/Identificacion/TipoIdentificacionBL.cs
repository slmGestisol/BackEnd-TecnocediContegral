using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class TipoIdentificacionBL : ITipoIdentificacionBL
    {
        private readonly ITiposIdentificacionDAL _tipoIdentificacionDAL;
        public TipoIdentificacionBL(ITiposIdentificacionDAL tipoIdentificacionDAL)
        {
            this._tipoIdentificacionDAL = tipoIdentificacionDAL;
        }
        public async Task<List<TiposIdentificaciones>> GetTiposIdentificacionesAsync()
        {
            return await this._tipoIdentificacionDAL.GetTiposIdentificacionesAsync();
        }



        public async Task<TiposIdentificaciones> GetTipoIdentificacionAsync(long id)
        {
            return await this._tipoIdentificacionDAL.GetTipoIdentificacionAsync(id);
        }



        public void AddIdentificacion(TiposIdentificaciones tipoIdentificacion)
        {
            this._tipoIdentificacionDAL.AddTipoIdentificacion(tipoIdentificacion);

        }

        public void DeleteIdentificacion(long id)
        {
            this._tipoIdentificacionDAL.DeleteTipoIdentificacion(id);

        }

        public bool IdentificacionExists(long id)
        {
            return this._tipoIdentificacionDAL.TipoIdentificacionExists(id);
        }
    }
}


