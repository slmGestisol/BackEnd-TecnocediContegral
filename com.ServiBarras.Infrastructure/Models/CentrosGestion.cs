using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CentrosGestion
    {
        public long centroGestionId { get; set; }
        public string centroGestionCodigo { get; set; }
        public string centroGestionDescripcion { get; set; }
        public long? ordenanteId { get; set; }

        public virtual Ordenantes ordenante { get; set; }
    }
}
