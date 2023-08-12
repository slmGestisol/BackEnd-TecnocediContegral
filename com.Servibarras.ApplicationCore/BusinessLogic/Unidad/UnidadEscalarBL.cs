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
    public class UnidadEscalarBL : IUnidadEscalarBL
    {
        private readonly IUnidadEscalarDAL _unidadEscalarDAL;
        public UnidadEscalarBL(IUnidadEscalarDAL unidadEscalarDAL)
        {
            this._unidadEscalarDAL = unidadEscalarDAL;
        }

        public async Task<IEnumerable<UnidadesEscalares>> GetUnidadesEscalaresAsync()
        {
            return await this._unidadEscalarDAL.GetUnidadesEscalarAsync();
        }



        public async Task<UnidadesEscalares> GetUnidadEscalarAsync(long id)
        {
            return await this._unidadEscalarDAL.GetUnidadEscalarAsync(id);
        }




        public void AddUnidadEscalar(JObject unidadEscalarJson)
        {
            try
            {

                var unidadEscalarDTO = JsonConvert.DeserializeObject<UnidadEscalarDTO>(unidadEscalarJson.ToString());

                UnidadesEscalares _unidadEscalar = new UnidadesEscalares();

                _unidadEscalar.unidadEscalarDescripcion = unidadEscalarDTO.unidadEscalarDescripcion;
                _unidadEscalar.unidadEscalarCodigo = unidadEscalarDTO.unidadEscalarCodigo;
                _unidadEscalar.unidadEscalarCantidad = Convert.ToDecimal(unidadEscalarDTO.unidadEscalarCantidad);
                _unidadEscalar.unidadEscalarTipo = Convert.ToInt16(unidadEscalarDTO.unidadEscalarTipo);
                _unidadEscalar.unidadEscalarCantidad = Convert.ToDecimal(unidadEscalarDTO.unidadEscalarCantidad);
                _unidadEscalar.unidadEscalarTipo = Convert.ToInt16(unidadEscalarDTO.unidadEscalarTipo);



                this._unidadEscalarDAL.AddUnidadEscalar(_unidadEscalar);

            }
            catch (Exception)
            {

                throw;
            }



        }

        public void DeleteUnidadEscalar(long id)
        {
            this._unidadEscalarDAL.DeleteUnidadEscalar(id);

        }

        public bool UnidadEscalarExists(long id)
        {
            return this._unidadEscalarDAL.UnidadEscalarExists(id);
        }
    }
}
