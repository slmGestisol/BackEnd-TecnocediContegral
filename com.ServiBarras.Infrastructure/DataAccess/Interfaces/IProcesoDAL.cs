using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProcesoDAL
    {
        List<NovedadDto> GetNovedadesByNameProceso(string nombreProceso);

        /// <summary>
        /// Ejecuta sp_GET_Procesos y devuelve los procesos para el combo,
        /// ordenados por nombre.
        /// </summary>
        Task<IReadOnlyList<ProcesoComboDto>> ObtenerProcesosAsync();
    }
}