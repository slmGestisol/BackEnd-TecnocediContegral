using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TXPicking
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

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
