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
    public class RFIDBL : IRFIDBL
    {
        private readonly IRFIDDAL _rfidDAL;

        public RFIDBL(IRFIDDAL rfidDAL)
        {
            this._rfidDAL = rfidDAL;
        }

        public DataSet GetPortalRFIDContenedores(long idPortal,long despachoConsecutivo,string inicioCaptura)
        {
            return this._rfidDAL.GetPortalRFIDContenedores(idPortal, despachoConsecutivo, inicioCaptura);
        }

    }
}
