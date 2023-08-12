using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TiposIdentificaciones
    {
        public TiposIdentificaciones()
        {
            Identificaciones = new HashSet<Identificaciones>();
        }

        public long tipoIdentificacionId { get; set; }
        public string tipoIdentificacionCodigo { get; set; }
        public string tipoIdentificacionDescripcion { get; set; }
        public byte tipoIdentificacionEstado { get; set; }

        public virtual ICollection<Identificaciones> Identificaciones { get; set; }
    }
}
