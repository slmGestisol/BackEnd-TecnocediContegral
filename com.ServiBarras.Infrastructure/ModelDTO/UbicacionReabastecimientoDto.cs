namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Ubicación elegible para asignar al proceso de reabastecimiento.
    /// Mapea SP_GET_UbicacionesReabastecimiento.
    /// </summary>
    public class UbicacionReabastecimientoDto
    {
        public long ubicacionId { get; set; }

        public string ubicacionCodigo { get; set; }

        public string ubicacionEtiqueta { get; set; }

        public string ubicacionDescripcion { get; set; }
    }
}
