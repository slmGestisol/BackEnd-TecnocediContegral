using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ContactoPuntoOperacionDAL : IContactoPuntoOperacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public ContactoPuntoOperacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        /// <summary>
        /// Método que consulta los Puntos de operación
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContactosPuntosOperaciones>> GetContactosPuntosOperacionAsync()
        {
            return await dbcontext.ContactosPuntosOperaciones.ToListAsync();
        }


        /// <summary>
        /// Método que consulta un Punto de operación según el ContactoPuntoOperacionId
        /// </summary>
        /// <param name="ContactoPuntoOperacionId"></param>
        /// <returns></returns>
        public async Task<ContactosPuntosOperaciones> GetContactoPuntoOperacionAsync(long contactoPuntoOperacionId)
        {
            var contactoPuntoOperacion = await dbcontext.ContactosPuntosOperaciones.FindAsync(contactoPuntoOperacionId);
            return contactoPuntoOperacion;
        }
        /// <summary>
        /// Método que actualiza un Punto de operación según el ContactoPuntoOperacionId
        /// </summary>
        /// <param name="ContactoPuntoOperacionId"></param>
        /// <param name="ContactoPuntoOperacion"></param>
        /// <returns></returns>
        public async Task UpdateContactoPuntoOperacionsAsync(long contactoId, ContactosPuntosOperaciones contactoPuntoOperacion)
        {
            if (contactoId != contactoPuntoOperacion.contactoId)
            {

            }

            dbcontext.Entry(contactoPuntoOperacion).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!ContactoPuntoOperacionExists(contactoId))
                {

                }
                else
                {
                    throw;
                }
            }


        }
        /// <summary>
        /// Método que inserta un Punto de operación 
        /// </summary>
        /// <param name="ContactoPuntoOperacion"></param>
        public void AddContactoPuntoOperacion(ContactosPuntosOperaciones contactoPuntoOperacion)
        {
            dbcontext.ContactosPuntosOperaciones.Add(contactoPuntoOperacion);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina un Punto de operación según el ContactoPuntoOperacionId
        /// </summary>
        /// <param name="ContactoPuntoOperacionId"></param>
        //public void DeleteContactoPuntoOperacion(long ContactoPuntoOperacionId)
        //{
        //    var ContactoPuntoOperacion = dbcontext.ContactosPuntosOperacion.Find(ContactoPuntoOperacionId);
        //    if (ContactoPuntoOperacion == null)
        //    {

        //    }

        //    dbcontext.ContactosPuntosOperacion.Remove(ContactoPuntoOperacion);
        //    dbcontext.SaveChanges();


        //}
        /// <summary>
        /// Método que valida si existe o no un Punto operación
        /// </summary>
        /// <param name="ContactoPuntoOperacionId"></param>
        /// <returns></returns>
        public bool ContactoPuntoOperacionExists(long ContactoId)
        {
            return dbcontext.ContactosPuntosOperaciones.Any(e => e.contactoId == ContactoId);
        }
    }
}
