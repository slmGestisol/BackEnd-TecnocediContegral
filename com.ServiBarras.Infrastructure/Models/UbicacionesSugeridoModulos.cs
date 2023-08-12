using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UbicacionesSugeridoModulos
    {
        public long ubicacionModuloId { get; set; }
        public string ubicacionModuloCodigo { get; set; }
        public long? productoId { get; set; }
        public int? ubicacionModuloEstado { get; set; }
        public int? ubicacionModuloCantidadUbicaciones { get; set; }
        public int? ubicacionModuloOrden { get; set; }
    }
}
