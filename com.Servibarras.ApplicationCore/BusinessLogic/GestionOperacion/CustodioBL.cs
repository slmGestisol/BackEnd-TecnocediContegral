using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CustodioBL : ICustodioBL
    {
        private readonly ICustodioDAL _custodioDAL;
        public CustodioBL(ICustodioDAL custodioDAL)
        {
            this._custodioDAL = custodioDAL;
        }
        public async Task<List<Custodios>> GetCustodiosAsync()
        {
            return await this._custodioDAL.GetCustodiosAsync();
        }



        public async Task<Custodios> GetCustodioAsync(long id)
        {
            return await this._custodioDAL.GetCustodioAsync(id);
        }

        public async Task AddCustodioAsync(JObject custodioJson)
        {
            try
            {
                Custodios custodio = new Custodios();

                var custodioAux = JsonConvert.DeserializeObject<CustodioDTO>(custodioJson.ToString());

                custodio.custodioCodigo = custodioAux.custodioCodigo;
                custodio.custodioDescripcion = custodioAux.custodioDescripcion;
                custodio.ordenanteId = Convert.ToInt64(custodioAux.ordenanteId);

                await this._custodioDAL.AddCustodioAsync(custodio);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }

        }


    }
}
