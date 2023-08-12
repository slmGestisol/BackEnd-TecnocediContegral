using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ListasPuntosOperacion
    {
        public ListasPuntosOperacion()
        {
            AtributosPuntosOperaciones = new HashSet<AtributosPuntosOperaciones>();
            PuntosOperaciones = new HashSet<PuntosOperaciones>();
        }

        public long listaPuntoOperacionId { get; set; }
        public string listaPuntoOperacionDescripcion { get; set; }

        public virtual ICollection<AtributosPuntosOperaciones> AtributosPuntosOperaciones { get; set; }
        public virtual ICollection<PuntosOperaciones> PuntosOperaciones { get; set; }
    }
}
