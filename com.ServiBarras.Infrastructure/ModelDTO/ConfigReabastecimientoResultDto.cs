namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Resultado de los SPs transaccionales de configuración de reabastecimiento
    /// (SP_SET_GuardarConfigReabastecimiento / SP_SET_InactivarConfigReabastecimiento).
    /// exitoso = false -> validación fallida: el API responde 400 con el mensaje.
    /// </summary>
    public class ConfigReabastecimientoResultDto
    {
        public bool exitoso { get; set; }

        public string mensaje { get; set; }

        // Id nuevo o existente del maestro; null en inactivación o validación fallida
        public long? configReabastecimientoProductoId { get; set; }
    }
}
