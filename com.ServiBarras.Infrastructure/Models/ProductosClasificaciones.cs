using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ProductosClasificaciones
    {
        public long productoId { get; set; }
        public long clasificacionId { get; set; }

        public virtual ClasificacionesProductos clasificacion { get; set; }
        public virtual Productos producto { get; set; }
    }
}
