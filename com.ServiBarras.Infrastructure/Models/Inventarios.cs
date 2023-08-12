using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Inventarios
    {
        public long InventarioId { get; set; }
        public DateTime InventarioFecha { get; set; }
        public long usuarioId { get; set; }
        public long? documentoId { get; set; }
        public long? ubicacionId { get; set; }
        public long? presentacionId { get; set; }
        public long? ubicacionSaldo { get; set; }
        public int? concepto { get; set; }

        public virtual Presentaciones presentacion { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
        public virtual Usuarios usuario { get; set; }
    }
}
