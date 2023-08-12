using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CriteriosPresentaciones
    {
        public CriteriosPresentaciones()
        {
            ClasificacionesPresentaciones = new HashSet<ClasificacionesPresentaciones>();
        }

        public long criterioPresentacionId { get; set; }
        public string criterioPresentacionDescripcion { get; set; }
        public byte criterioPresentacionEstado { get; set; }
        public byte criterioProductoMultiple { get; set; }

        public virtual ICollection<ClasificacionesPresentaciones> ClasificacionesPresentaciones { get; set; }
    }
}
