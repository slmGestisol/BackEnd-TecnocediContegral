using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CambioSloting
    {
        public int id { get; set; }
        public string productoCodigo { get; set; }
        public string calle { get; set; }
        public string modulo { get; set; }
        public string columna { get; set; }
        public long? productoId { get; set; }
        public long? ubicacionid { get; set; }
    }
}
