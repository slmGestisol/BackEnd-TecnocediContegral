using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TiposUbicaciones
    {
        public TiposUbicaciones()
        {
            Ubicaciones = new HashSet<Ubicaciones>();
        }

        public int tipoUbicacionId { get; set; }
        public string tipoUbicacionCodigo { get; set; }
        public string tipoUbicacionDescripcion { get; set; }
        public byte tipoUbicacionEstado { get; set; }

        public virtual ICollection<Ubicaciones> Ubicaciones { get; set; }
    }
}
