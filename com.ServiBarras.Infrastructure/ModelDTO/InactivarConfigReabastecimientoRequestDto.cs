namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Body de POST api/inactivarConfigReabastecimiento.
    /// </summary>
    public class InactivarConfigReabastecimientoRequestDto
    {
        public long configReabastecimientoProductoId { get; set; }

        public long usuarioId { get; set; }
    }
}
