using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CiudadBL : ICiudadBL
    {

        private readonly ICiudadDAL _ciudadDAL;

        public CiudadBL(ICiudadDAL ciudadDAL)
        {
            this._ciudadDAL = ciudadDAL;
        }
        /// <summary>
        /// Método que consulta las ciudades
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ciudades>> GetCiudadesAsync()
        {
            return await this._ciudadDAL.GetCiudadesAsync();
        }
        /// <summary>
        /// Método que consulta una ciudad según el ciudadId
        /// </summary>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        public async Task<Ciudades> GetCiudadAsync(long ciudadId)
        {
            return await this._ciudadDAL.GetCiudadAsync(ciudadId);
        }

        /// <summary>
        /// Método que inserta una ciudad en la tabla ciudades
        /// </summary>
        /// <param name="ciudad"></param>
        public void AddCiudad(Ciudades estado)
        {
            this._ciudadDAL.AddCiudad(estado);

        }
        /// <summary>
        /// Método que elimina una ciudad 
        /// </summary>
        /// <param name="ciudadId"></param>
        public void DeleteCiudad(long ciudadId)
        {
            this._ciudadDAL.DeleteCiudad(ciudadId);

        }
        /// <summary>
        /// Método que valida si existe o no una ciudad
        /// </summary>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        public bool CiudadExists(long ciudadId)
        {
            return this._ciudadDAL.CiudadExists(ciudadId);
        }
    }
}