using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Ordenantes
    {
        public Ordenantes()
        {
            CentrosGestion = new HashSet<CentrosGestion>();
            CentrosOperaciones = new HashSet<CentrosOperaciones>();
            Custodios = new HashSet<Custodios>();
            Titulares = new HashSet<Titulares>();
        }

        public long ordenanteId { get; set; }
        public string ordenanteDescripcion { get; set; }
        public string ordenanteCodigo { get; set; }

        public virtual ICollection<CentrosGestion> CentrosGestion { get; set; }
        public virtual ICollection<CentrosOperaciones> CentrosOperaciones { get; set; }
        public virtual ICollection<Custodios> Custodios { get; set; }
        public virtual ICollection<Titulares> Titulares { get; set; }
    }
}
