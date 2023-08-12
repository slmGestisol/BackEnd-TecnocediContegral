using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ClasificacionesProductos
    {
        public ClasificacionesProductos()
        {
            ClasificacionesAtributosProductos = new HashSet<ClasificacionesAtributosProductos>();
            ClasificacionesPlantillasProductos = new HashSet<ClasificacionesPlantillasProductos>();
            ProductosClasificaciones = new HashSet<ProductosClasificaciones>();
        }

        public long clasificacionProductoId { get; set; }
        public string clasificacionProductoDescripcion { get; set; }
        public byte clasificacionProductoEstado { get; set; }
        public long? criterioProductoId { get; set; }

        public virtual CriteriosProductos criterioProducto { get; set; }
        public virtual ICollection<ClasificacionesAtributosProductos> ClasificacionesAtributosProductos { get; set; }
        public virtual ICollection<ClasificacionesPlantillasProductos> ClasificacionesPlantillasProductos { get; set; }
        public virtual ICollection<ProductosClasificaciones> ProductosClasificaciones { get; set; }
    }
}
