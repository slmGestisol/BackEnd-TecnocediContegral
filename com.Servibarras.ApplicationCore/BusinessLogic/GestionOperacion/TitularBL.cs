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
    public class TitularBL : ITitularBL
    {
        private readonly ITitularDAL _titularDAL;
        public TitularBL(ITitularDAL titularDAL)
        {
            this._titularDAL = titularDAL;
        }
        public async Task<IEnumerable<Titulares>> GetTitularesAsync()
        {
            return await this._titularDAL.GetTitularesAsync();
        }



        public async Task<Titulares> GetTitularAsync(long id)
        {
            return await this._titularDAL.GetTitularAsync(id);
        }



        public void AddTitular(JObject titularJson)
        {
            try
            {
                var titularDTO = JsonConvert.DeserializeObject<TitularDTO>(titularJson.ToString());

                Titulares titular = new Titulares();
                titular.titularDescripcion = titularDTO.titularDescripcion;
                titular.titularCodigo = titularDTO.titularCodigo;
                titular.ordenanteId = Convert.ToInt32(titularDTO.ordenanteId);
                this._titularDAL.AddTitular(titular);

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }

        }

        public void DeleteTitular(long id)
        {
            this._titularDAL.DeleteTitular(id);

        }

        public bool TitularExists(long id)
        {
            return this._titularDAL.TitularExists(id);
        }
    }
}
