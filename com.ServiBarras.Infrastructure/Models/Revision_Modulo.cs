using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Revision_Modulo
    {
        public long Id { get; set; }
        public long? ProductoId { get; set; }
        public long? N_Modulo { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? fecha { get; set; }
        public long? ubicacionid { get; set; }
    }
}
