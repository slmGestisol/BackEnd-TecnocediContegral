using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ContactosPuntosOperaciones
    {
        public long contactoId { get; set; }
        public long puntoOperacionId { get; set; }

        public virtual Contactos contacto { get; set; }
        public virtual PuntosOperaciones puntoOperacion { get; set; }
    }
}
