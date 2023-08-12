using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class EstadoBL : IEstadoBL
    {
        private readonly IEstadoDAL _estadoDAL;

        public EstadoBL(IEstadoDAL estadoDAL)
        {
            this._estadoDAL = estadoDAL;
        }

        public async Task<List<Estados>> GetEstadosAsync()
        {
            return await this._estadoDAL.GetEstadosAsync();
        }



        public async Task<Estados> GetEstadoAsync(long id)
        {
            return await this._estadoDAL.GetEstadoAsync(id);
        }




        public void AddEstado(Estados estado)
        {
            this._estadoDAL.AddEstado(estado);

        }

        public void DeleteEstado(long id)
        {
            this._estadoDAL.DeleteEstado(id);

        }

        public bool EstadoExists(long id)
        {
            return this._estadoDAL.EstadoExists(id);
        }
    }
}