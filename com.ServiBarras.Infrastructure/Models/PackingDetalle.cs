using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PackingDetalle
    {
        public long packingId { get; set; }
        public long packingDetalleId { get; set; }
        public decimal? packingDetalleCantTotal { get; set; }
        public decimal? packingDetalleCantSolicitada { get; set; }
        public decimal? packingDetalleCantPreparada { get; set; }
        public decimal? packingDetalleCantNovedad { get; set; }
        public long ubicacionMedioId { get; set; }
        public long presentacionId { get; set; }
        public long ruteoId { get; set; }
        public long ruteoDetalleId { get; set; }
        public long? novedadId { get; set; }
        public long? pedidoId { get; set; }
        public long? pedidoDetalleId { get; set; }
        public long? ubicacionBahiaId { get; set; }
        public byte packingEstado { get; set; }
        public Guid? packingDetalleGlobalId { get; set; }
        public DateTime? packingDetalleFechaCreacion { get; set; }
        public DateTime? packingDetalleFechaModificacion { get; set; }
        public long? usuarioId { get; set; }

        public virtual Novedades novedad { get; set; }
        public virtual Packing packing { get; set; }
        public virtual Pedidos pedido { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ruteos ruteo { get; set; }
        public virtual RuteosDetalle ruteoDetalle { get; set; }
        public virtual Ubicaciones ubicacionMedio { get; set; }
    }
}
