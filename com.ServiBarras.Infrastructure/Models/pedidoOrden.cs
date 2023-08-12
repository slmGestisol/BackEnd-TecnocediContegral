using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class pedidoOrden
    {
        public long pedidoOrdenId { get; set; }
        public long? ruteoId { get; set; }
        public long? productoId { get; set; }
        public int? orden { get; set; }
        public long? usuarioId { get; set; }
        public bool? prioridad { get; set; }
    }
}
