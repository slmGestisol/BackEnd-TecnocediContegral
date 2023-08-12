using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Contactos
    {
        public Contactos()
        {
            ContactosPuntosOperaciones = new HashSet<ContactosPuntosOperaciones>();
        }

        public long contactoId { get; set; }

        public virtual ICollection<ContactosPuntosOperaciones> ContactosPuntosOperaciones { get; set; }
    }
}
