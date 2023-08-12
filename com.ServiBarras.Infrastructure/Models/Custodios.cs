using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Custodios
    {
        public Custodios()
        {
            PuntosOperaciones = new HashSet<PuntosOperaciones>();
        }

        public long custodioId { get; set; }
        public string custodioDescripcion { get; set; }
        public string custodioCodigo { get; set; }
        public long ordenanteId { get; set; }

        public virtual Ordenantes ordenante { get; set; }
        public virtual ICollection<PuntosOperaciones> PuntosOperaciones { get; set; }
    }
}
