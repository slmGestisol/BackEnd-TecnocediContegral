namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Body de POST api/guardarNovedad (crear o editar).
    /// novedadId = 0 / null -> creación; con valor > 0 -> edición.
    /// Se envía tal cual a sp_SET_GuardarNovedades.
    /// </summary>
    public class GuardarNovedadRequestDto
    {
        public int? novedadId { get; set; }

        public string novedadCodigo { get; set; }

        public string novedadNombre { get; set; }

        public string novedadDescripcion { get; set; }

        public int procesoId { get; set; }

        public int usuarioId { get; set; }
    }
}
