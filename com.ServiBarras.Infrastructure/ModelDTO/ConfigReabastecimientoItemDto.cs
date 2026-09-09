using System;

namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Fila de la tabla maestro de configuraciones de reabastecimiento activas.
    /// Mapea exactamente las columnas de SP_GET_ConfigReabastecimiento.
    /// </summary>
    public class ConfigReabastecimientoItemDto
    {
        public long configReabastecimientoProductoId { get; set; }

        public long productoId { get; set; }

        public string productoCodigo { get; set; }

        public string productoDescripcion { get; set; }

        public decimal cantidadMinima { get; set; }

        public decimal cantidadMaxima { get; set; }

        public decimal configToleranciaNotificacion { get; set; }

        // Conteo de filas activas en ConfigReabastecimientoUbicacion del producto
        public int totalUbicaciones { get; set; }

        public DateTime fechaCreacion { get; set; }
    }
}
