using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxInventario
    {
        public long txInventarioId { get; set; }
        public int txInventarioConcepto { get; set; }
        public long txInventarioConsecutivo { get; set; }
        public long? inventarioId { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? txInventarioRealManejo { get; set; }
        public decimal? txInventarioRealEscalar { get; set; }
        public long? documentoId { get; set; }
        public byte txInventarioEstado { get; set; }
        public long? txInventarioParentId { get; set; }
        public DateTime? txInventarioFechaCreacion { get; set; }
        public DateTime? txInventarioFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public bool? incompleto { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
