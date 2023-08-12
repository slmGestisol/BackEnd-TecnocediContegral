using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxReubicacion
    {
        public long txReubicacionId { get; set; }
        public int txReubicacionConcepto { get; set; }
        public long txReubicacionConsecutivo { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? txReubicacionRealManejo { get; set; }
        public decimal? txReubicacionRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? saldoId { get; set; }
        public long? saldoDetalleId { get; set; }
        public long? documentoId { get; set; }
        public byte txReubicacionEstado { get; set; }
        public long? txReubicacionParentId { get; set; }
        public DateTime? txReubicacionFechaCreacion { get; set; }
        public DateTime? txReubicacionFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public int? txReubicacionPosicionSeleccionada { get; set; }
        public bool? txReubicacionBarcode { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
