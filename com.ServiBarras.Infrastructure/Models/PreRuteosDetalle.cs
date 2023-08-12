using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PreRuteosDetalle
    {
        public long preRuteoId { get; set; }
        public long preRuteoDetalleId { get; set; }
        public long novedadId { get; set; }
        public byte preRuteoPedidoEstado { get; set; }
        public long? presentacionId { get; set; }
        public long? bodegaLogicaId { get; set; }
        public long? ubicacionId { get; set; }
        public decimal? preRuteoDetalleCantidad { get; set; }
        public decimal? preRuteoDetalleCantNovedad { get; set; }
        public decimal? preRuteoDetalleCantRequerida { get; set; }
        public byte preRuteoDetalleEstado { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long? saldoId { get; set; }
        public long? saldoUbicacionId { get; set; }
        public long? ubicacionBahiaId { get; set; }
        public byte? esCrossDocking { get; set; }
        public long? usuarioIdModificacion { get; set; }
        public DateTime? preRuteoDetalleFechaModificacion { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual PreRuteos preRuteo { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual SaldosUbicaciones saldoUbicacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
