using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PedidosPreRuteo
    {
        public long pedidoId { get; set; }
        public long UserNameId { get; set; }
        public Guid? UniqueProcessId { get; set; }
        public bool? Estado { get; set; }
        public bool? Secuencial { get; set; }
        public Guid? SecuencialUniqueProcessId { get; set; }
    }
}
