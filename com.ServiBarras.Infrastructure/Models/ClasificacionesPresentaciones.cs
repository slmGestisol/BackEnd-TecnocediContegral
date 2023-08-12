using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ClasificacionesPresentaciones
    {
        public ClasificacionesPresentaciones()
        {
            PresentacionesClasificacion = new HashSet<PresentacionesClasificacion>();
        }

        public long clasificacionPresentacionId { get; set; }
        public string clasificacionPresentacionDescripcion { get; set; }
        public byte clasificacionPresentacionEstado { get; set; }
        public long criterioProductoId { get; set; }

        public virtual CriteriosPresentaciones criterioProducto { get; set; }
        public virtual ICollection<PresentacionesClasificacion> PresentacionesClasificacion { get; set; }
    }
}
