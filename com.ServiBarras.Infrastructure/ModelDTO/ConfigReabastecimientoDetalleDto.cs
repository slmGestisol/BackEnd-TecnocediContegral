using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Configuración completa de un producto (maestro + ubicaciones activas)
    /// para el panel de edición. Mapea SP_GET_ConfigReabastecimientoDetalle.
    /// </summary>
    public class ConfigReabastecimientoDetalleDto
    {
        public long configReabastecimientoProductoId { get; set; }

        public long productoId { get; set; }

        public string productoCodigo { get; set; }

        public string productoDescripcion { get; set; }

        public decimal cantidadMinima { get; set; }

        public decimal cantidadMaxima { get; set; }

        public decimal configToleranciaNotificacion { get; set; }

        // Sólo filas con Activo = 1, ordenadas por orden ascendente
        public List<ConfigReabastecimientoUbicacionDto> ubicaciones { get; set; } = new List<ConfigReabastecimientoUbicacionDto>();
    }
}
