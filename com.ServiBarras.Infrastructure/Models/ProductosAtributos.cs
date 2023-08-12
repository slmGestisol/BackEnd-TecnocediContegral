using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ProductosAtributos
    {
        public long productoId { get; set; }
        public string productoAtributoValor { get; set; }
        public long productoPlantillaId { get; set; }

        public virtual Productos producto { get; set; }
        public virtual PlantillasProductos productoPlantilla { get; set; }
    }
}
