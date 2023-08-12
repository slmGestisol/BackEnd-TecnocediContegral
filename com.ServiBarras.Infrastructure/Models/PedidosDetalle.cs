using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PedidosDetalle
    {
        public long pedidoId { get; set; }
        public long pedidoDetalleId { get; set; }
        public long puntoEnvioId { get; set; }
        public long? consolidadorId { get; set; }
        public long productoId { get; set; }
        public long productoTipoId { get; set; }
        public long? presentacionId { get; set; }
        public decimal pedidoDetalleCantidad { get; set; }
        public byte pedidoDetalleEstado { get; set; }
        public DateTime pedidoDetalleFecha { get; set; }
        public short pedidoDetalleVersion { get; set; }

        public virtual Pedidos pedido { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Productos producto { get; set; }
        public virtual PuntosEnvio puntoEnvio { get; set; }
    }
}
