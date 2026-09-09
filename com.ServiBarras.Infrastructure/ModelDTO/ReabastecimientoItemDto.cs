namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Mapea exactamente las columnas del stored procedure sp_GET_ReabastecimientoData.
    /// Las cantidades y saldos usan decimal para no perder precisión.
    /// </summary>
    public class ReabastecimientoItemDto
    {
        public int productoId { get; set; }

        public string productoCodigo { get; set; }

        public string productoDescripcion { get; set; }

        public decimal CantidadMinima { get; set; }

        public decimal CantidadMaxima { get; set; }

        public decimal ConfigToleranciaNotificacion { get; set; }

        public decimal SaldoReal { get; set; }

        public decimal SaldoComprometido { get; set; }

        public decimal CantidadSugeridaReponer { get; set; }
        public int? reabastecimientoSolicitudId { get; set; }       

        // "CRITICO" | "PROXIMO" | "OK"
        public string Estado { get; set; }
    }
}
