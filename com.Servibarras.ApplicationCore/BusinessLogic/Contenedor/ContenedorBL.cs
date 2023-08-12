using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ContenedorBL : IContenedorBL
    {

        private readonly IContenedorDAL _contenedorDAL;
        public ContenedorBL(IContenedorDAL contenedorDAL)
        {
            this._contenedorDAL = contenedorDAL;
        }

        public async Task<List<Contenedores>> GetContenedoresAsync()
        {
            return await this._contenedorDAL.GetContenedoresAsync();
        }



        public async Task<Contenedores> GetContenedorAsync(long contenedorId)
        {
            return await this._contenedorDAL.GetContenedorAsync(contenedorId);
        }




        public void AddContenedor(Contenedores contenedor)
        {
            this._contenedorDAL.AddContenedor(contenedor);

        }

        public void DeleteContenedor(long contenedorId)
        {


        }

        public bool ContenedorExists(long contenedorId)
        {
            return this._contenedorDAL.ContenedorExists(contenedorId);
        }


        public DataSet GetContenedoresByContenedorCodigo(JObject parametrosContenedor)
        {
            var contenedorAux = JsonConvert.DeserializeObject<ContenedorUbicacionParcialDTO>(parametrosContenedor.ToString());
            return this._contenedorDAL.GetContenedoresByContenedorCodigo(contenedorAux);
        }


        public DataSet GetContenedoresByContenedorCodigoBarcode(string contenedorCodigo)
        {
           
            return this._contenedorDAL.GetContenedoresByContenedorCodigoBarcode(contenedorCodigo);
        }
       

        public DataSet GetValidarContenedorByUbicacion(JObject parametrosContenedor)
        {
            var contenedorAux = JsonConvert.DeserializeObject<ContenedorUbicacionParcialDTO>(parametrosContenedor.ToString());
            return this._contenedorDAL.GetValidarContenedorByUbicacion(contenedorAux);
        }

        public DataSet GetValidarContenedorExterno(JObject parametrosContenedor)
        {
            var contenedorAux = JsonConvert.DeserializeObject<ContenedorUbicacionParcialDTO>(parametrosContenedor.ToString());
            return this._contenedorDAL.GetValidarContenedorExterno(contenedorAux);
        }
    }
}