using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PuntoOperacionBL : IPuntoOperacionBL
    {
        private readonly IPuntoOperacionDAL _puntoOperacionDAL;
       
        public PuntoOperacionBL(IPuntoOperacionDAL puntoOperacionDAL)
        {
            this._puntoOperacionDAL = puntoOperacionDAL;
        }
        /// <summary>
        /// Método que consulta los Puntos de operación
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PuntosOperaciones>> GetPuntosOperacionAsync()
        {
            return await this._puntoOperacionDAL.GetPuntosOperacionAsync();
        }
        /// <summary>
        /// Método que consulta un Punto de operación según el PuntoOperacionId
        /// </summary>
        /// <param name="puntoOperacionId"></param>
        /// <returns></returns>
        public async Task<PuntosOperaciones> GetPuntoOperacionAsync(long puntoOperacionId)
        {
            return await this._puntoOperacionDAL.GetPuntoOperacionAsync(puntoOperacionId);
        }
        /// <summary>
        /// Método que actualiza un Punto de operación según el puntoOperacionId
        /// </summary>
        /// <param name="puntoOperacionId"></param>
        /// <param name="puntoOperacion"></param>
        /// <returns></returns>

        /// <summary>
        /// Método que inserta un Punto de operación 
        /// </summary>
        /// <param name="puntoOperacion"></param>
        public void AddPuntoOperacion(PuntosOperaciones puntoOperacion)
        {
            this._puntoOperacionDAL.AddPuntoOperacion(puntoOperacion);
        }
        /// <summary>
        /// Método que elimina un Punto de operación según el puntoOperacionId
        /// </summary>
        /// <param name="puntoOperacionId"></param>
        public void DeletePuntoOperacion(long puntoOperacionId)
        {
            this._puntoOperacionDAL.DeletePuntoOperacion(puntoOperacionId);

        }
        /// <summary>
        /// Método que valida si existe o no un Punto
        /// </summary>
        /// <param name="puntoOperacionId"></param>
        /// <returns></returns>
        public bool PuntoOperacionExists(long puntoOperacionId)
        {
            return this._puntoOperacionDAL.PuntoOperacionExists(puntoOperacionId);
        }
    }
}
