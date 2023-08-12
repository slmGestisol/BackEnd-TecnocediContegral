using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RutasUbicaciones
    {
        public long rutaUbicacionId { get; set; }
        public long rutaId { get; set; }
        public long ubicacionId { get; set; }
        public int rutaUbicacionOrden { get; set; }
    }
}
