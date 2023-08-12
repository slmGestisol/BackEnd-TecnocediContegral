using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IContactoPuntoOperacionBL
    {
        void AddContactoPuntoOperacion(ContactosPuntosOperaciones contactoPuntoOperacion);
        bool ContactoPuntoOperacionExists(long ContactoId);
        Task<ContactosPuntosOperaciones> GetContactoPuntoOperacionAsync(long contactoPuntoOperacionId);
        Task<List<ContactosPuntosOperaciones>> GetContactosPuntosOperacionAsync();

    }
}