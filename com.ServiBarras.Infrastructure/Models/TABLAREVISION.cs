using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TABLAREVISION
    {
        public int ID { get; set; }
        public long? UBICACIONID { get; set; }
        public string ubicacionCodigoCambio { get; set; }
        public long? ordenEmpaqueId { get; set; }
        public long? estacionId { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? FECHA { get; set; }
        public string RESULTADO { get; set; }
    }
}
