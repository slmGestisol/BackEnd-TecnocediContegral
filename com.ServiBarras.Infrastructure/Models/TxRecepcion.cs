using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxRecepcion
    {
        public long txRecepcionId { get; set; }
        public int txRecepcionConcepto { get; set; }
        public long txRecepcionConsecutivo { get; set; }
        public long? recepcionId { get; set; }
        public long? recepcionDetalleId { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? txRecepcionRealManejo { get; set; }
        public decimal? txRecepcionRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? saldoId { get; set; }
        public long? saldoDetalleId { get; set; }
        public long? documentoId { get; set; }
        public byte txRecepcionEstado { get; set; }
        public long? txRecepcionParentId { get; set; }
        public DateTime? txRecepcionFechaCreacion { get; set; }
        public DateTime? txRecepcionFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public long? usuarioIdModificicacion { get; set; }
    }
}
