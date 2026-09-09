namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Producto activo sin configuración de reabastecimiento activa, elegible
    /// para crear una configuración nueva. Mapea SP_GET_ProductosSinConfigReabastecimiento.
    /// </summary>
    public class ProductoSinConfigReabastecimientoDto
    {
        public long productoId { get; set; }

        public string productoCodigo { get; set; }

        public string productoDescripcion { get; set; }
    }
}
