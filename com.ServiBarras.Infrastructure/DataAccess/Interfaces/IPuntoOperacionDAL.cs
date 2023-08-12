using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPuntoOperacionDAL
    {
        void AddPuntoOperacion(PuntosOperaciones puntoOperacion);
        void DeletePuntoOperacion(long puntoOperacionId);
        Task<PuntosOperaciones> GetPuntoOperacionAsync(long puntoOperacionId);
        Task<List<PuntosOperaciones>> GetPuntosOperacionAsync();
        bool PuntoOperacionExists(long puntoOperacionId);
        Task UpdatePuntoOperacionsAsync(long puntoOperacionId, PuntosOperaciones puntoOperacion);
    }
}