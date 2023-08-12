using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class DespachosDetalle
    {
        public long despachoId { get; set; }
        public long despachoDetalleId { get; set; }
        public decimal? despachoDetalleCantTotal { get; set; }
        public decimal? despachoDetalleCantSolicitada { get; set; }
        public decimal? despachoDetalleCantPreparada { get; set; }
        public decimal? despachoDetalleCantNovedad { get; set; }
        public long ubicacionId { get; set; }
        public long presentacionId { get; set; }
        public long ruteoId { get; set; }
        public long ruteoDetalleId { get; set; }
        public long? novedadId { get; set; }
        public long? pedidoId { get; set; }
        public long? pedidoDetalleId { get; set; }
        public byte despachoEstado { get; set; }
        public long? ubicacionActualId { get; set; }
        public DateTime? despachoDetalleFechaCreacion { get; set; }
        public DateTime? despachoDetalleFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public decimal? despachoDetalleCantDespachada { get; set; }
        public long? usuarioIdDespacho { get; set; }
        public byte? usuarioIdEstado { get; set; }

        public virtual Despachos despacho { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Pedidos pedido { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ruteos ruteo { get; set; }
        public virtual RuteosDetalle ruteoDetalle { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
        public virtual Usuarios usuarioIdDespachoNavigation { get; set; }
    }
}
