using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class EstacionBL : IEstacionBL
    {
        private readonly IEstacionDAL _estacionDAL;
        public EstacionBL(IEstacionDAL estacionDAL)
        {
            this._estacionDAL = estacionDAL;
        }

        public DataSet GetEstaciones(string tipoEstacionCodigo)
        {
            return this._estacionDAL.GetEstaciones(tipoEstacionCodigo);
        }

        public DataSet GetUbicacionesByEstacionId(long estacionId)
        {
            return this._estacionDAL.GetUbicacionesByEstacionId(estacionId);
        }


    }
}
