using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ConfiguracionVerificacion
    {
        public long configuracionVerificacionId { get; set; }
        public string configuracionVerificacionCodigo { get; set; }
        public string configuracionVerificacionDescripcion { get; set; }
        public string configuracionVerificacionPassword { get; set; }
    }
}
