using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ImpresionBL : IImpresionBL
    {
        private readonly IImpresionDAL _impresionDAL;
        public ImpresionBL(IImpresionDAL impresionDAL)
        {
            this._impresionDAL = impresionDAL;
        }

        public DataSet getImpresoras()
        {
            return this._impresionDAL.getImpresoras();
        }


    }
}
