using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TrazabilidadPromociones
    {
        public long trazabilidadPromocionId { get; set; }
        public long? usuarioId { get; set; }
        public long? promocionId { get; set; }
        public bool? trazabilidadPromocionEstado { get; set; }
        public DateTime? trazabilidadPromocionFecha { get; set; }
        public long? ordenEmpaqueId { get; set; }
    }
}
