using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class CoronaExtrasBL : ICoronaExtrasBL
    {
        private readonly ICoronaExtrasDAL _CoronaExtrasDAL;

        public CoronaExtrasBL(ICoronaExtrasDAL coronaExtras)
        {
            this._CoronaExtrasDAL = coronaExtras;
        }

        public DataSet getMercadosEstandaresByProducto(long productoId)
        {
            return this._CoronaExtrasDAL.getMercadosEstandaresByProducto(productoId);
        }

    }
}
