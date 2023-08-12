using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UnidadesManejo
    {
        public UnidadesManejo()
        {
            Productos = new HashSet<Productos>();
        }

        public long unidadManejoId { get; set; }
        public string unidadManejoCodigo { get; set; }
        public string unidadManejoDescripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
