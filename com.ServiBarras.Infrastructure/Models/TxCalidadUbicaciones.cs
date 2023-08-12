using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxCalidadUbicaciones
    {
        public long TxCalidadUbicacionId { get; set; }
        public int TxCalidadUbicacionConcepto { get; set; }
        public long TxCalidadUbicacionConsecutivo { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorConsecutivo { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long? bodegaLogicaId { get; set; }
        public decimal TxCalidadUbicacionSUMRealManejo { get; set; }
        public decimal TxCalidadUbicacionSUMRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? documentoId { get; set; }
        public byte TxCalidadUbicacionEstado { get; set; }
        public DateTime? TxCalidadUbicacionFechaCreacion { get; set; }
        public DateTime? TxCalidadUbicacionFechaModificacion { get; set; }
        public long? usuarioId { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
