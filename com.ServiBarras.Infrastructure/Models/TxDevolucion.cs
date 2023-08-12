using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxDevolucion
    {
        public long TxDevolucionId { get; set; }
        public int TxDevolucionConcepto { get; set; }
        public long TxDevolucionConsecutivo { get; set; }
        public long? devolucionId { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long contenedorId { get; set; }
        public long? contenedorConsecutivo { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal TxDevolucionRealManejo { get; set; }
        public decimal TxDevolucionRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? documentoId { get; set; }
        public byte TxDevolucionEstado { get; set; }
        public DateTime? TxDevolucionFechaCreacion { get; set; }
        public DateTime? TxDevolucionFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public string proceso { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
