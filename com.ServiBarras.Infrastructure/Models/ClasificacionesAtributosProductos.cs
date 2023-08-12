using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ClasificacionesAtributosProductos
    {
        public long clasificacionId { get; set; }
        public long atributoProductoId { get; set; }

        public virtual AtributosProductos atributoProducto { get; set; }
        public virtual ClasificacionesProductos clasificacion { get; set; }
    }
}
