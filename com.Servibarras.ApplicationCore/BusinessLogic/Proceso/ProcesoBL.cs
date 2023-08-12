using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ProcesoBL : IProcesoBL
    {
        private readonly IProcesoDAL _procesoDAL;
        public ProcesoBL(IProcesoDAL procesoDAL)
        {
            this._procesoDAL = procesoDAL;
        }
        public List<Novedades> GetNovedadesByNameProceso(string nombreProceso)
        {
            return this._procesoDAL.GetNovedadesByNameProceso(nombreProceso);
        }




    }
}
