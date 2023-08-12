using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public class IdentificacionBL : IIdentificacionBL
    {

        private readonly IIdentificacionDAL _identificacionDAL;
        public IdentificacionBL(IIdentificacionDAL identificacionDAL)
        {
            this._identificacionDAL = identificacionDAL;
        }

        public async Task<List<Identificaciones>> GetIdentificacionesAsync()
        {
            return await this._identificacionDAL.GetIdentificacionesAsync();
        }



        public async Task<Identificaciones> GetIdentificacionAsync(long id)
        {
            return await this._identificacionDAL.GetIdentificacionAsync(id);
        }




        public void AddIdentificacion(Identificaciones Identificacion)
        {
            this._identificacionDAL.AddIdentificacion(Identificacion);

        }

        public void DeleteIdentificacion(long id)
        {
            this._identificacionDAL.DeleteIdentificacion(id);

        }

        public bool IdentificacionExists(long id)
        {
            return this._identificacionDAL.IdentificacionExists(id);
        }
    }
}


