using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class PaisBL : IPaisBL
    {

        private readonly IPaisDAL _paisDAL;

        public PaisBL(IPaisDAL paisDAL)
        {
            this._paisDAL = paisDAL;
        }

        public async Task<List<Paises>> GetPaisesAsync()
        {
            return await this._paisDAL.GetPaisesAsync();
        }

        public async Task<Paises> GetPaisAsync(long id)
        {
            return await this._paisDAL.GetPaisAsync(id);
        }



        public void AddPais(Paises pais)
        {
            this._paisDAL.AddPais(pais);
        }

        public void DeletePais(long id)
        {
            this._paisDAL.DeletePais(id);
        }

        public bool PaisExists(long id)
        {
            return this._paisDAL.PaisExists(id);
        }

    }
}