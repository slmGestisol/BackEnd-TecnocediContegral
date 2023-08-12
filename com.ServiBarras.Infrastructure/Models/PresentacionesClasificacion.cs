using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PresentacionesClasificacion
    {
        public long clasificacionPresentacionId { get; set; }
        public long presentacionId { get; set; }

        public virtual ClasificacionesPresentaciones clasificacionPresentacion { get; set; }
        public virtual Presentaciones presentacion { get; set; }
    }
}
