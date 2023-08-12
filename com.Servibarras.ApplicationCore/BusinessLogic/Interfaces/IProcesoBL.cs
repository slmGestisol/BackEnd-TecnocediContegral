using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProcesoBL
    {
        List<Novedades> GetNovedadesByNameProceso(string nombreProceso);
    }
}