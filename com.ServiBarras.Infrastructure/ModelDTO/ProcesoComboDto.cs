namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Elemento del combo de procesos (resultado de sp_GET_Procesos).
    /// </summary>
    public class ProcesoComboDto
    {
        public int procesoId { get; set; }

        public string procesoCodigo { get; set; }

        public string procesoNombre { get; set; }
    }
}
