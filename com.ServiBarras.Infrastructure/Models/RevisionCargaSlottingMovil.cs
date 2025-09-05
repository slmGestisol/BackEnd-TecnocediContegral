using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RevisionCargaSlottingMovil
    {
        public long cargaSlottingMovilId { get; set; }
        public DateTime? fechaCarga { get; set; }
        public long? usuarioId { get; set; }
    }
}
