using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PlantillasProductos
    {
        public PlantillasProductos()
        {
            ProductosAtributos = new HashSet<ProductosAtributos>();
        }

        public long plantillaProductoId { get; set; }
        public long? plantillaProductoAtributoId { get; set; }
        public long? productoId { get; set; }

        public virtual PlantillasProductosAtributos plantillaProductoAtributo { get; set; }
        public virtual Productos producto { get; set; }
        public virtual ICollection<ProductosAtributos> ProductosAtributos { get; set; }
    }
}
