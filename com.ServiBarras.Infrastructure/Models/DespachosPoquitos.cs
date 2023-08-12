using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class DespachosPoquitos
    {
        public long DespachoPoquitosId { get; set; }
        public long? BahiaId { get; set; }
        public long? PedidoId { get; set; }
        public long? PresentacionId { get; set; }
        public decimal? CantidadPedido { get; set; }
        public decimal? CantidadDespachada { get; set; }
        public long? RuteoId { get; set; }
        public bool? bahia0 { get; set; }
        public bool? Estado { get; set; }
    }
}
