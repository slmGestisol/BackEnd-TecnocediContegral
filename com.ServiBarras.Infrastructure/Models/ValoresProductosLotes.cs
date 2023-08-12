using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ValoresProductosLotes
    {
        public long valorProductoLoteId { get; set; }
        public string valorProductoLoteDescripcion { get; set; }
        public DateTime? valorProductoLoteFecha { get; set; }
    }
}
