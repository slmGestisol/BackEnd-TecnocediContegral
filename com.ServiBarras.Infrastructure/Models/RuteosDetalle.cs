using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RuteosDetalle
    {
        public RuteosDetalle()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
            PackingDetalle = new HashSet<PackingDetalle>();
        }

        public long ruteoId { get; set; }
        public long ruteoDetalleId { get; set; }
        public long novedadId { get; set; }
        public byte ruteoPedidoEstado { get; set; }
        public long? presentacionId { get; set; }
        public long? bodegaLogicaId { get; set; }
        public long? ubicacionId { get; set; }
        public decimal? ruteoDetalleCantidad { get; set; }
        public decimal? ruteoDetalleCantNovedad { get; set; }
        public decimal? ruteoDetalleCantRequerida { get; set; }
        public byte ruteoDetalleEstado { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long? grupoId { get; set; }
        public int? Cambio { get; set; }
        public int? RuteoIdAux { get; set; }
        public int? RuteoDetalleIdAux { get; set; }
        public int? UbicacionIdAxu { get; set; }
        public string Transaccion { get; set; }
        public long? ubicacionBahiaId { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? ruteoDetalleFechaCierreRuteo { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Coordenadas contenedor { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Ruteos ruteo { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
    }
}
