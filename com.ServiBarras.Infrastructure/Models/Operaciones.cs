using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Operaciones
    {
        public Operaciones()
        {
            Estaciones = new HashSet<Estaciones>();
        }

        public long operacionId { get; set; }
        public string operacionDescripcion { get; set; }

        public virtual ICollection<Estaciones> Estaciones { get; set; }
    }
}
