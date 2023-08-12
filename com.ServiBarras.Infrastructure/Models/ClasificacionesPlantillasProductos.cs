using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ClasificacionesPlantillasProductos
    {
        public long clasificacionId { get; set; }
        public long plantillaProductoId { get; set; }

        public virtual ClasificacionesProductos clasificacion { get; set; }
        public virtual PlantillasProductosAtributos plantillaProducto { get; set; }
    }
}
