using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.Servibarras.ApplicationCore.BusinessLogic.BodegaLogica
{
    public class BodegaLogicaBL : IBodegaLogicaBL
    {
        private readonly IBodegaLogicaDAL _bodegaLogicaDAL;

        public BodegaLogicaBL(IBodegaLogicaDAL bodegaLogicaDAL)
        {
            this._bodegaLogicaDAL = bodegaLogicaDAL;

        }
        public DataSet getBodegasLogicasByProcesoNombre(string procesoNombre)
        {
            return this._bodegaLogicaDAL.getBodegasLogicasByProcesoNombre(procesoNombre);
        }
    }
}
