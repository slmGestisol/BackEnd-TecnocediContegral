namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Ubicación activa parametrizada a un producto en el panel de edición.
    /// Mapea el segundo result set de SP_GET_ConfigReabastecimientoDetalle.
    /// </summary>
    public class ConfigReabastecimientoUbicacionDto
    {
        public long configReabastecimientoUbicacionId { get; set; }

        public long ubicacionId { get; set; }

        public string ubicacionCodigo { get; set; }

        public int orden { get; set; }
    }
}
