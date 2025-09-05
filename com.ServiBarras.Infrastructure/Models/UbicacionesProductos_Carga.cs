using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UbicacionesProductos_Carga
    {
        public long id { get; set; }
        public string productoCodigo { get; set; }
        public long? ubicacionId { get; set; }
        public long? orden { get; set; }
    }
}
