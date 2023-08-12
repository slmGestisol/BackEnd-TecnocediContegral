using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ProductosSustituciones
    {
        public long productoSustitucionId { get; set; }
        public long productoIdOrigenPS { get; set; }
        public long productoIdDestinoPS { get; set; }
        public long productoSustitucionOrden { get; set; }
        public byte productoSustitucionEstado { get; set; }
        public decimal productoSustitucionCantidad { get; set; }
    }
}
