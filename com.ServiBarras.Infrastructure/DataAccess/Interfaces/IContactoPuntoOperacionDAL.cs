using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IContactoPuntoOperacionDAL
    {
        void AddContactoPuntoOperacion(ContactosPuntosOperaciones contactoPuntoOperacion);
        bool ContactoPuntoOperacionExists(long ContactoId);
        Task<ContactosPuntosOperaciones> GetContactoPuntoOperacionAsync(long contactoPuntoOperacionId);
        Task<List<ContactosPuntosOperaciones>> GetContactosPuntosOperacionAsync();
        Task UpdateContactoPuntoOperacionsAsync(long contactoId, ContactosPuntosOperaciones contactoPuntoOperacion);
    }
}