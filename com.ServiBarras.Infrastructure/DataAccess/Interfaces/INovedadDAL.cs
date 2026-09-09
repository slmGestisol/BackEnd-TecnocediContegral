using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface INovedadDAL
    {
        Task<List<Novedades>> GetNovedadAsync(long novedadId);
        Task<List<NovedadesAcciones>> GetNovedadAccionesAsync();
        Task<List<Novedades>> GetNovedadesbyProcesoId(int procesoId);
        DataSet GetNovedadByNovedadCodigo(string novedadCodigo);

        /// <summary>
        /// Ejecuta sp_GET_novedades y devuelve las novedades para la grilla.
        /// procesoId = null -> todos los procesos; incluirInactivas = false -> solo activas.
        /// </summary>
        Task<IReadOnlyList<NovedadItemDto>> ObtenerNovedadesAsync(int? procesoId, bool incluirInactivas);

        /// <summary>
        /// Ejecuta sp_SET_GuardarNovedades (crear o editar).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<NovedadResultDto> GuardarNovedadAsync(GuardarNovedadRequestDto request);

        /// <summary>
        /// Ejecuta sp_SET_Novedades_CambiarEstado (borrado lógico / reactivación).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<NovedadResultDto> CambiarEstadoNovedadAsync(int novedadId, bool activo, int usuarioId);
    }
}