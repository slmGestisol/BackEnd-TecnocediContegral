using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
  public  interface INovedadBL
    {
        Task<List<Novedades>> GetNovedadAsync(long novedadId);
        Task<List<NovedadesAcciones>> GetNovedadesAccionesAsync();
        Task<List<Novedades>> GetNovedadesbyProcesoId(int procesoId);
        DataSet GetNovedadByNovedadCodigo(string novedadCodigo);
       
    }
}