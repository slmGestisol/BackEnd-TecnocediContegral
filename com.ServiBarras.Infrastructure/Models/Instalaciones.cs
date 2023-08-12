using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Instalaciones
    {
        public Instalaciones()
        {
            Ubicaciones = new HashSet<Ubicaciones>();
        }

        public long instalacionId { get; set; }
        public string instalacionCodigo { get; set; }
        public string instalacionDescripcion { get; set; }

        public virtual ICollection<Ubicaciones> Ubicaciones { get; set; }
    }
}
