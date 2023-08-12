using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CentroOperacionBL : ICentroOperacionBL
    {
        private readonly ICentroOperacionDAL _centroOperacionDAL;

        public CentroOperacionBL(ICentroOperacionDAL centroOperacionDAL)
        {
            this._centroOperacionDAL = centroOperacionDAL;
        }
        /// <summary>
        /// Método que consulta los centros de operación
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CentrosOperaciones>> GetCentrosOperacionAsync()
        {
            return await this._centroOperacionDAL.GetCentrosOperacionAsync();
        }
        /// <summary>
        /// Método que consulta un centro de operación según el centroOperacionId
        /// </summary>
        /// <param name="centroOperacionId"></param>
        /// <returns></returns>
        public async Task<CentrosOperaciones> GetCentroOperacionAsync(long centroOperacionId)
        {
            return await this._centroOperacionDAL.GetCentroOperacionAsync(centroOperacionId);
        }

        /// <summary>
        /// Método que inserta un centro de operación 
        /// </summary>
        /// <param name="centroOperacion"></param>
        public void AddCentroOperacion(CentrosOperaciones centroOperacion)
        {
            this._centroOperacionDAL.AddCentroOperacion(centroOperacion);
        }
        /// <summary>
        /// Método que elimina un centro de operación según el centroOperacionId
        /// </summary>
        /// <param name="centroOperacionId"></param>
        public void DeleteCentroOperacion(long centroOperacionId)
        {
            this._centroOperacionDAL.DeleteCentroOperacion(centroOperacionId);

        }
        /// <summary>
        /// Método que valida si existe o no un centro
        /// </summary>
        /// <param name="centroOperacionId"></param>
        /// <returns></returns>
        public bool CentroOperacionExists(long centroOperacionId)
        {
            return this._centroOperacionDAL.CentroOperacionExists(centroOperacionId);
        }
    }
}
