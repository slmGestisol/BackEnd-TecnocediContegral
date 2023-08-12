using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ProductosLotes
    {
        public long productoLoteId { get; set; }
        public long productoId { get; set; }
        public long plantillaLoteId { get; set; }

        public virtual PlantillasLotes plantillaLote { get; set; }
        public virtual Productos producto { get; set; }
    }
}
