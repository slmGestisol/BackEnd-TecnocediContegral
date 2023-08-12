using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ProductosContenedores
    {
        public long productoId { get; set; }
        public long contenedorId { get; set; }

        public virtual Contenedores contenedor { get; set; }
        public virtual Productos producto { get; set; }
    }
}
