using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UbicacionesProductos
    {
        public long ubicacionProductoId { get; set; }
        public long? ubicacionId { get; set; }
        public long? productoId { get; set; }
        public int? ubicacionProductoOrden { get; set; }

        public virtual Productos producto { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
    }
}
