using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RuteosPedidos
    {
        public long ruteoId { get; set; }
        public long pedidoId { get; set; }
        public long? bahiaId { get; set; }
        public short? pedidoOrden { get; set; }
        public bool pedidoProcesado { get; set; }
        public DateTime? ruteoPedidoFechaCreacion { get; set; }
        public DateTime? ruteoPedidoFechaCIerre { get; set; }
        public long? usuarioIdCierre { get; set; }

        public virtual Pedidos pedido { get; set; }
        public virtual Ruteos ruteo { get; set; }
    }
}
