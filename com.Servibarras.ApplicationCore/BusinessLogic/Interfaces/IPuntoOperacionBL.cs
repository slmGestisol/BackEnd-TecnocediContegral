using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IPuntoOperacionBL
    {
        void AddPuntoOperacion(PuntosOperaciones puntoOperacion);
        void DeletePuntoOperacion(long puntoOperacionId);
        Task<PuntosOperaciones> GetPuntoOperacionAsync(long puntoOperacionId);
        Task<IEnumerable<PuntosOperaciones>> GetPuntosOperacionAsync();
        bool PuntoOperacionExists(long puntoOperacionId);

    }
}