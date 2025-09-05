using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PedidosAgrupados
    {
        public long Id { get; set; }
        public long pedidoIdOriginal { get; set; }
        public long pedidoIdConsolidado { get; set; }
        public Guid uniqueProcessIdOriginal { get; set; }
        public Guid uniqueProcessIdConsolidado { get; set; }
        public long usuarioId { get; set; }
        public DateTime? fechaAgrupacion { get; set; }
    }
}
