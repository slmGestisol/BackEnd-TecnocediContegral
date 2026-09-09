namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Body de POST api/cambiarEstadoNovedad (borrado lógico / reactivación).
    /// activo = false -> inactivar; activo = true -> activar.
    /// Se envía a sp_SET_Novedades_CambiarEstado.
    /// </summary>
    public class CambiarEstadoNovedadRequestDto
    {
        public int novedadId { get; set; }

        public bool activo { get; set; }

        public int usuarioId { get; set; }
    }
}
