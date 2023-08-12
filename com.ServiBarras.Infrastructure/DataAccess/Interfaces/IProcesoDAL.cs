using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProcesoDAL
    {
        List<Novedades> GetNovedadesByNameProceso(string nombreProceso);
    }
}