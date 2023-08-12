using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PlantillasProductosAtributos
    {
        public PlantillasProductosAtributos()
        {
            AtributosProductos = new HashSet<AtributosProductos>();
            ClasificacionesPlantillasProductos = new HashSet<ClasificacionesPlantillasProductos>();
            PlantillasProductos = new HashSet<PlantillasProductos>();
        }

        public long plantillaProductoAtributoId { get; set; }
        public string plantillaProductoAtributoDescripcion { get; set; }
        public byte? plantillaProductoAtributoEstado { get; set; }

        public virtual ICollection<AtributosProductos> AtributosProductos { get; set; }
        public virtual ICollection<ClasificacionesPlantillasProductos> ClasificacionesPlantillasProductos { get; set; }
        public virtual ICollection<PlantillasProductos> PlantillasProductos { get; set; }
    }
}
