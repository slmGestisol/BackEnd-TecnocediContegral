using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PreRuteosPedidos
    {
        public long preRuteoId { get; set; }
        public long pedidoId { get; set; }

        public virtual Pedidos pedido { get; set; }
        public virtual PreRuteos preRuteo { get; set; }
    }
}
