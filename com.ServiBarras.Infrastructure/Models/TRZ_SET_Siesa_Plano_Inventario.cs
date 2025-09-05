using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TRZ_SET_Siesa_Plano_Inventario
    {
        public long id { get; set; }
        public long? ubicacionId { get; set; }
        public long? ordenEmpaqueId { get; set; }
        public string nombreArchivo { get; set; }
        public DateTime? fecha { get; set; }
    }
}
