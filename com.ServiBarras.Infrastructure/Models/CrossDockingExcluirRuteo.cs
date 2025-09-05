using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CrossDockingExcluirRuteo
    {
        public long crossDockingExcluirRuteoId { get; set; }
        public long? PedidoId { get; set; }
        public long? PresentacionId { get; set; }
        public long? UsuarioId { get; set; }
        public DateTime? CrossDockingExcluirRuteoFecha { get; set; }
        public bool? estado { get; set; }
    }
}
