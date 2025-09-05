using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class trzOrdenEmpaqueCierreUbicacionEstiba
    {
        public long Id { get; set; }
        public long? ubicacionId { get; set; }
        public long? ordenEmpaqueId { get; set; }
        public long? estacionId { get; set; }
        public string estadoEstibaUbicacion { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public long? paso { get; set; }
        public string resultado { get; set; }
        public DateTime? fechaInicioImpresion { get; set; }
        public DateTime? fechaFinImpresion { get; set; }
        public string ejecucionImpresion { get; set; }
    }
}
