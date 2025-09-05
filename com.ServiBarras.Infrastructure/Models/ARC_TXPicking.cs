using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ARC_TXPicking
    {
        public long tXPickingId { get; set; }
        public int tXPickingConcepto { get; set; }
        public long tXPickingConsecutivo { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? tXPickingRealManejo { get; set; }
        public decimal? tXPickingRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? ruteoId { get; set; }
        public long? ruteoDetalleId { get; set; }
        public long? documentoId { get; set; }
        public byte tXPickingEstado { get; set; }
        public long? txPickingParentId { get; set; }
        public DateTime? txPickingFechaCreacion { get; set; }
        public DateTime? txPickingFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public bool? continuidadActivada { get; set; }
    }
}
