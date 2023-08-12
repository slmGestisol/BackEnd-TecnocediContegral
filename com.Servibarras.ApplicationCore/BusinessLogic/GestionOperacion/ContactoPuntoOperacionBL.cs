using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ContactoPuntoOperacionBL : IContactoPuntoOperacionBL
    {
        private readonly IContactoPuntoOperacionDAL _contactoPuntoOperacionDAL;

        public ContactoPuntoOperacionBL(IContactoPuntoOperacionDAL contactoPuntoOperacionDAL)
        {
            this._contactoPuntoOperacionDAL = contactoPuntoOperacionDAL;
        }
        /// <summary>
        /// Método que consulta los Puntos de operación
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContactosPuntosOperaciones>> GetContactosPuntosOperacionAsync()
        {
            return await this._contactoPuntoOperacionDAL.GetContactosPuntosOperacionAsync();
        }


        /// <summary>
        /// Método que consulta un Punto de operación según el ContactoPuntoOperacionId
        /// </summary>
        /// <param name="ContactoPuntoOperacionId"></param>
        /// <returns></returns>
        public async Task<ContactosPuntosOperaciones> GetContactoPuntoOperacionAsync(long contactoPuntoOperacionId)
        {
            return await this._contactoPuntoOperacionDAL.GetContactoPuntoOperacionAsync(contactoPuntoOperacionId);
        }

        /// <summary>
        /// Método que inserta un Punto de operación 
        /// </summary>
        /// <param name="ContactoPuntoOperacion"></param>
        public void AddContactoPuntoOperacion(ContactosPuntosOperaciones contactoPuntoOperacion)
        {
            this._contactoPuntoOperacionDAL.AddContactoPuntoOperacion(contactoPuntoOperacion);

        }
      
        /// <summary>
        /// Método que valida si existe o no un Punto operación
        /// </summary>
        /// <param name="ContactoPuntoOperacionId"></param>
        /// <returns></returns>
        public bool ContactoPuntoOperacionExists(long ContactoId)
        {
            return this._contactoPuntoOperacionDAL.ContactoPuntoOperacionExists(ContactoId);
        }
    }
}
