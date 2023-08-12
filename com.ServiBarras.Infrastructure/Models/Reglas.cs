using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Reglas
    {
        public long ReglaId { get; set; }
        public long PuntoEnvioId { get; set; }
        public long ProductoId { get; set; }
        public int reglaCaducidadValor { get; set; }

        public virtual Productos Producto { get; set; }
        public virtual PuntosEnvio PuntoEnvio { get; set; }
    }
}
