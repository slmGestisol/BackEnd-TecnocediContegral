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
    public class OrdenanteBL : IOrdenanteBL
    {

        private readonly IOrdenanteDAL _ordenanteDAL;
        public OrdenanteBL(IOrdenanteDAL ordenanteDAL)
        {
            this._ordenanteDAL = ordenanteDAL;
        }
        public async Task<List<Ordenantes>> GetOrdenantesAsync()
        {
            return await this._ordenanteDAL.GetOrdenantesAsync();
        }



        public async Task<Ordenantes> GetOrdenanteAsync(long id)
        {
            return await this._ordenanteDAL.GetOrdenanteAsync(id);
        }

        public void AddOrdenante(JObject ordenanteJson)
        {
            try
            {
                var ordenanteDTO = JsonConvert.DeserializeObject<OrdenanteDTO>(ordenanteJson.ToString());

                Ordenantes ordenante = new Ordenantes();
                ordenante.ordenanteDescripcion = ordenanteDTO.ordenanteDescripcion;
                ordenante.ordenanteCodigo = ordenanteDTO.ordenanteCodigo;

                this._ordenanteDAL.AddOrdenante(ordenante);

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
