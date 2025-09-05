using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ubicacionesSustitucion
    {
        public long ubicacionSustitucionId { get; set; }
        public long? ubicacionIdOrigen { get; set; }
        public long? ubicacionIdSustitucion { get; set; }
        public bool? estado { get; set; }
    }
}
