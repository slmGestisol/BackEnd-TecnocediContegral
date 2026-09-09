using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IConfigReabastecimientoDAL
    {
        /// <summary>
        /// Ejecuta SP_GET_ConfigReabastecimiento y devuelve las configuraciones
        /// activas con datos del producto para la tabla maestro.
        /// </summary>
        Task<IReadOnlyList<ConfigReabastecimientoItemDto>> ObtenerConfiguracionesAsync();

        /// <summary>
        /// Ejecuta SP_GET_ConfigReabastecimientoDetalle y devuelve la configuración
        /// completa (maestro + ubicaciones activas) de un producto.
        /// Devuelve null si la configuración no existe o está inactiva.
        /// </summary>
        Task<ConfigReabastecimientoDetalleDto> ObtenerDetalleAsync(long configReabastecimientoProductoId);

        /// <summary>
        /// Ejecuta SP_GET_ProductosSinConfigReabastecimiento y devuelve los productos
        /// activos sin configuración de reabastecimiento activa.
        /// </summary>
        Task<IReadOnlyList<ProductoSinConfigReabastecimientoDto>> ObtenerProductosSinConfigAsync();

        /// <summary>
        /// Ejecuta SP_GET_UbicacionesReabastecimiento y devuelve las ubicaciones
        /// elegibles para asignar al proceso de reabastecimiento.
        /// </summary>
        Task<IReadOnlyList<UbicacionReabastecimientoDto>> ObtenerUbicacionesElegiblesAsync();

        /// <summary>
        /// Ejecuta SP_SET_GuardarConfigReabastecimiento (guardado atómico maestro + detalle).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<ConfigReabastecimientoResultDto> GuardarAsync(GuardarConfigReabastecimientoRequestDto request);

        /// <summary>
        /// Ejecuta SP_SET_InactivarConfigReabastecimiento (inactivación definitiva
        /// del maestro con detalle en cascada).
        /// exitoso = false en el resultado indica validación fallida (HTTP 400).
        /// </summary>
        Task<ConfigReabastecimientoResultDto> InactivarAsync(long configReabastecimientoProductoId, long usuarioId);
    }
}
