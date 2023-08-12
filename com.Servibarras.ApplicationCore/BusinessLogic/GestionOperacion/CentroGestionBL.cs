using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CentroGestionBL : ICentroGestionBL
    {
        private readonly ICentroGestionDAL _centroGestionDAL;

        public CentroGestionBL(ICentroGestionDAL centroGestionDAL)
        {
            this._centroGestionDAL = centroGestionDAL;
        }
        /// <summary>
        /// Método que consulta todos los centros de gestion
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CentrosGestion>> GetCentrosGestionAsync()
        {
           
            return await this._centroGestionDAL.GetCentrosGestionAsync();
        }
        /// <summary>
        /// Método que consulta el centro de gestión por centroGestionId
        /// </summary>
        /// <param name="centroGestionId"></param>
        /// <returns></returns>
        public async Task<CentrosGestion> GetCentroGestionAsync(long centroGestionId)
        {
            
            return await this._centroGestionDAL.GetCentroGestionAsync(centroGestionId);
        }
        /// <summary>
        /// Método que actualiza el centro de gestión seleccionado
        /// </summary>
        /// <param name="centroGestionId"></param>
        /// <param name="centroGestion"></param>
        /// <returns></returns>

        /// <summary>
        /// Método que agrega un centro de gestión
        /// </summary>
        /// <param name="centroGestion"></param>
        public void AddCentroGestion(CentrosGestion centroGestion)
        {
            this._centroGestionDAL.AddCentroGestion(centroGestion);

        }
        /// <summary>
        /// Método que elimina el centro de gestión seleccionado
        /// </summary>
        /// <param name="centroGestionId"></param>
        public void DeleteCentroGestion(long centroGestionId)
        {
            this._centroGestionDAL.DeleteCentroGestion(centroGestionId);

        }
        /// <summary>
        /// Método que valida si existe o no un centro de gestión
        /// </summary>
        /// <param name="centroGestionId"></param>
        /// <returns></returns>
        public bool CentroGestionExists(long centroGestionId)
        {
            return this._centroGestionDAL.CentroGestionExists(centroGestionId);
        }
    }
}
