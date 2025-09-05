using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Promociones
    {
        public long promocionId { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? promocionFechaCreacion { get; set; }
        public long? NumeroCodigoPromocionales { get; set; }
        public bool? promocionEstado { get; set; }
        public string productoCodigo { get; set; }
    }
}
