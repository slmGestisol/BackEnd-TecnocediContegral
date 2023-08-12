using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TXPacking
    {
        public long tXPackingId { get; set; }
        public int tXPackingConcepto { get; set; }
        public long tXPackingConsecutivo { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? tXPackingRealManejo { get; set; }
        public decimal? tXPackingRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? ruteoId { get; set; }
        public long? ruteoDetalleId { get; set; }
        public long? documentoId { get; set; }
        public byte tXPackingEstado { get; set; }
        public long? tXPackingParentId { get; set; }
        public DateTime? txPackingFechaCreacion { get; set; }
        public DateTime? txPackingFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public bool? continuidadActivada { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
