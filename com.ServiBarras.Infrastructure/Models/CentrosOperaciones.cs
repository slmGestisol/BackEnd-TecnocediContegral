using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CentrosOperaciones
    {
        public CentrosOperaciones()
        {
            PuntosOperaciones = new HashSet<PuntosOperaciones>();
        }

        public long centroOperacionId { get; set; }
        public string centroOperacionCodigo { get; set; }
        public string centroOperacionDescripcion { get; set; }
        public byte centroOperacionEstado { get; set; }
        public long ordenanteId { get; set; }

        public virtual Ordenantes ordenante { get; set; }
        public virtual ICollection<PuntosOperaciones> PuntosOperaciones { get; set; }
    }
}
