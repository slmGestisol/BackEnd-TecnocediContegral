using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class contenedoresReubicacionaParcial
    {
        public long contenedoresReubicacionaParcialId { get; set; }
        public long? usuarioId { get; set; }
        public long? contenedorId { get; set; }
        public long? ubicacionId { get; set; }
        public long? novedadId { get; set; }
        public string tipoMovimiento { get; set; }
        public Guid? uniqueProcessId { get; set; }
    }
}
