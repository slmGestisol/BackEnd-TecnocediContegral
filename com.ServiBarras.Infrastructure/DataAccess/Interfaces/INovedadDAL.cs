using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface INovedadDAL
    {
        Task<List<Novedades>> GetNovedadAsync(long novedadId);
        Task<List<NovedadesAcciones>> GetNovedadAccionesAsync();
        Task<List<Novedades>> GetNovedadesbyProcesoId(int procesoId);
        DataSet GetNovedadByNovedadCodigo(string novedadCodigo);
    }
}