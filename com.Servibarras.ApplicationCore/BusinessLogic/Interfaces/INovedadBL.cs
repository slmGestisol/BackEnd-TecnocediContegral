using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
  public  interface INovedadBL
    {
        Task<List<Novedades>> GetNovedadAsync(long novedadId);
        Task<List<NovedadesAcciones>> GetNovedadesAccionesAsync();
        Task<List<Novedades>> GetNovedadesbyProcesoId(int procesoId);
        DataSet GetNovedadByNovedadCodigo(string novedadCodigo);

        /// <summary>
        /// Novedades para la grilla del módulo de parametrización
        /// (resultado de sp_GET_novedades).
        /// </summary>
        Task<IReadOnlyList<NovedadItemDto>> ObtenerNovedadesAsync(int? procesoId, bool incluirInactivas);

        /// <summary>
        /// Crear o editar una novedad (sp_SET_GuardarNovedades).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<NovedadResultDto> GuardarNovedadAsync(GuardarNovedadRequestDto request);

        /// <summary>
        /// Borrado lógico / reactivación de una novedad (sp_SET_Novedades_CambiarEstado).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<NovedadResultDto> CambiarEstadoNovedadAsync(int novedadId, bool activo, int usuarioId);
    }
}