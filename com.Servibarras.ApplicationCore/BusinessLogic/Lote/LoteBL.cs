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
    public class LoteBL : ILoteBL
    {
        private readonly ILoteDAL _loteDAL;
        public LoteBL(ILoteDAL loteDAL)
        {
            this._loteDAL = loteDAL;
        }
        
        public DataSet GetLoteByLoteCodigo(string loteCodigo, long productoId)
        {
            return this._loteDAL.GetLoteByLoteCodigo(loteCodigo, productoId);
        }

    }
}
