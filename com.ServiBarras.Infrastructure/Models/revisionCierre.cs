using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class revisionCierre
    {
        public int id { get; set; }
        public long? ubicacionId { get; set; }
        public long? ordenEmpaqueId { get; set; }
        public long? estacionId { get; set; }
        public string estadoEstibaUbicacion { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? fecha { get; set; }
        public string resultado { get; set; }
    }
}
