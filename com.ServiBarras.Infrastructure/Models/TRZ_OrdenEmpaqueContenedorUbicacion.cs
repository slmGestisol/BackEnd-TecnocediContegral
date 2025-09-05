using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TRZ_OrdenEmpaqueContenedorUbicacion
    {
        public long trzId { get; set; }
        public string contenedorCodigo { get; set; }
        public long? ordenEmpaqueId { get; set; }
        public string ubicacionId { get; set; }
        public long? estacionId { get; set; }
        public string proceso { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? fecha { get; set; }
        public string resultado { get; set; }
    }
}
