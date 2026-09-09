using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Body de POST api/guardarConfigReabastecimiento.
    /// configReabastecimientoProductoId = null -> creación; con valor -> edición.
    /// ubicaciones es la lista completa y final en el orden deseado (no es un delta).
    /// </summary>
    public class GuardarConfigReabastecimientoRequestDto
    {
        public long? configReabastecimientoProductoId { get; set; }

        public long productoId { get; set; }

        public decimal cantidadMinima { get; set; }

        public decimal cantidadMaxima { get; set; }

        public decimal configToleranciaNotificacion { get; set; }

        public long usuarioId { get; set; }

        public List<GuardarConfigReabastecimientoUbicacionDto> ubicaciones { get; set; }
    }

    /// <summary>
    /// Elemento del arreglo de ubicaciones del guardado. Se serializa tal cual
    /// al parámetro @ubicacionesJson de SP_SET_GuardarConfigReabastecimiento.
    /// </summary>
    public class GuardarConfigReabastecimientoUbicacionDto
    {
        public long ubicacionId { get; set; }

        public int orden { get; set; }
    }
}
