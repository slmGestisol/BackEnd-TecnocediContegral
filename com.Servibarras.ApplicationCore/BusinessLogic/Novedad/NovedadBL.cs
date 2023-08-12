using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class NovedadBL : INovedadBL
    {
        private readonly INovedadDAL _novedadDAL;

        public NovedadBL(INovedadDAL novedadDAL)
        {
            this._novedadDAL = novedadDAL;
        }
        public async Task<List<Novedades>> GetNovedadAsync(long novedadId)
        {
            return await this._novedadDAL.GetNovedadAsync(novedadId);
        }


        public async Task<List<NovedadesAcciones>> GetNovedadesAccionesAsync()
        {
            return await this._novedadDAL.GetNovedadAccionesAsync();
        }

        public async Task<List<Novedades>> GetNovedadesbyProcesoId(int procesoId)
        {
            return await this._novedadDAL.GetNovedadesbyProcesoId(procesoId);
        }

        public DataSet GetNovedadByNovedadCodigo(string novedadCodigo)
        {
            return this._novedadDAL.GetNovedadByNovedadCodigo(novedadCodigo);
        }
    }
}
