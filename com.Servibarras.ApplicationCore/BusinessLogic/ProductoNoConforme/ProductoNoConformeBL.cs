using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ProductoNoConformeBL : IProductoNoConformeBL
    {


        private readonly IProductoNoConformeDAL _productoNoConformeDAL;
        public ProductoNoConformeBL(IProductoNoConformeDAL productoNoConformeDAL)
        {
            this._productoNoConformeDAL = productoNoConformeDAL;
        }
       
        public DataSet setGuardarNovedadesProductoNoConforme(JArray parametrosContenedoresNovedad)
        {
            var parametrosContenedoresNovedadAUX = JsonConvert.DeserializeObject<List<ProductoNoConformeGuardarNovedadesDTO>>(parametrosContenedoresNovedad.ToString());
            return _productoNoConformeDAL.setGuardarNovedadesProductoNoConforme(parametrosContenedoresNovedadAUX);
        }
    }
}
