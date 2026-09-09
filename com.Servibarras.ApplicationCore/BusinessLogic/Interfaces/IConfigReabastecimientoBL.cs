using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IConfigReabastecimientoBL
    {
        /// <summary>
        /// Configuraciones de reabastecimiento activas con datos del producto
        /// (resultado de SP_GET_ConfigReabastecimiento).
        /// </summary>
        Task<IReadOnlyList<ConfigReabastecimientoItemDto>> ObtenerConfiguracionesAsync();

        /// <summary>
        /// Configuración completa de un producto (maestro + ubicaciones activas).
        /// Devuelve null si no existe o está inactiva
        /// (resultado de SP_GET_ConfigReabastecimientoDetalle).
        /// </summary>
        Task<ConfigReabastecimientoDetalleDto> ObtenerDetalleAsync(long configReabastecimientoProductoId);

        /// <summary>
        /// Productos activos sin configuración de reabastecimiento activa
        /// (resultado de SP_GET_ProductosSinConfigReabastecimiento).
        /// </summary>
        Task<IReadOnlyList<ProductoSinConfigReabastecimientoDto>> ObtenerProductosSinConfigAsync();

        /// <summary>
        /// Ubicaciones elegibles para asignar al proceso de reabastecimiento
        /// (resultado de SP_GET_UbicacionesReabastecimiento).
        /// </summary>
        Task<IReadOnlyList<UbicacionReabastecimientoDto>> ObtenerUbicacionesElegiblesAsync();

        /// <summary>
        /// Guardado atómico de la configuración de un producto (maestro + detalle).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<ConfigReabastecimientoResultDto> GuardarAsync(GuardarConfigReabastecimientoRequestDto request);

        /// <summary>
        /// Inactivación definitiva de una configuración (maestro + detalle en cascada).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<ConfigReabastecimientoResultDto> InactivarAsync(long configReabastecimientoProductoId, long usuarioId);
    }
}
