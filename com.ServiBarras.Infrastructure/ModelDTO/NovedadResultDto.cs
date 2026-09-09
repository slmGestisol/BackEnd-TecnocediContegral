namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Resultado de los SPs transaccionales de novedades
    /// (sp_SET_GuardarNovedades / sp_SET_Novedades_CambiarEstado).
    /// exitoso = false -> validación fallida: el API responde 400 con el mensaje.
    /// </summary>
    public class NovedadResultDto
    {
        public bool exitoso { get; set; }

        public string mensaje { get; set; }

        // Id nuevo o existente de la novedad; null en validación fallida
        public int? novedadId { get; set; }
    }
}
