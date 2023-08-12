using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UbicacionesCambioAutomatico
    {
        public long ubicacionCambioAutomaticoId { get; set; }
        public long ubicacionId { get; set; }
        public int ubicacionCambioAutomaticoOrden { get; set; }

        public virtual Ubicaciones ubicacion { get; set; }
    }
}
