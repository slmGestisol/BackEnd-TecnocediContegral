using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Procesos
    {
        public Procesos()
        {
            Novedades = new HashSet<Novedades>();
        }

        public int ProcesoId { get; set; }
        public string ProcesoCodigo { get; set; }
        public string ProcesoNombre { get; set; }

        public virtual ICollection<Novedades> Novedades { get; set; }
    }
}
