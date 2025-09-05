using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class REVISION_CIERRE
    {
        public long id { get; set; }
        public long? puertaUbicacionId { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? FECHA { get; set; }
        public long? ruteoId { get; set; }
        public string resultado { get; set; }
    }
}
