using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProcesoBL
    {
        List<NovedadDto> GetNovedadesByNameProceso(string nombreProceso);

        /// <summary>
        /// Procesos para el combo, ordenados por nombre
        /// (resultado de sp_GET_Procesos).
        /// </summary>
        Task<IReadOnlyList<ProcesoComboDto>> ObtenerProcesosAsync();
    }
}