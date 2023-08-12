using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Estados = new HashSet<Estados>();
        }

        public long paisId { get; set; }
        public string paisCodigo { get; set; }
        public string paisCodigoDANE { get; set; }
        public string paisNombre { get; set; }

        public virtual ICollection<Estados> Estados { get; set; }
    }
}
