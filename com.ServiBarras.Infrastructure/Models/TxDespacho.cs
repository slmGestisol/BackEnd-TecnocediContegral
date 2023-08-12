using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxDespacho
    {
        public long txDespachoId { get; set; }
        public int txDespachoConcepto { get; set; }
        public long txDespachoConsecutivo { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? txDespachoRealManejo { get; set; }
        public decimal? txDespachoRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? ruteoId { get; set; }
        public long? ruteoDetalleId { get; set; }
        public long? documentoId { get; set; }
        public byte txDespachoEstado { get; set; }
        public long? txDespachoParentId { get; set; }
        public DateTime? txDespachoFechaCreacion { get; set; }
        public DateTime? txDespachoFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public long? PedidoId { get; set; }
        public bool? continuidadActivada { get; set; }
        public bool? incompleto { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual Identificaciones identificacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
