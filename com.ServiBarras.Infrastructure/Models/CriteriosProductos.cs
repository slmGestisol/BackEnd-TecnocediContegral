using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CriteriosProductos
    {
        public CriteriosProductos()
        {
            ClasificacionesProductos = new HashSet<ClasificacionesProductos>();
        }

        public long criterioProductoId { get; set; }
        public string criterioProductoDescripcion { get; set; }
        public byte criterioProductoEstado { get; set; }
        public byte criterioProductoMultiple { get; set; }

        public virtual ICollection<ClasificacionesProductos> ClasificacionesProductos { get; set; }
    }
}
