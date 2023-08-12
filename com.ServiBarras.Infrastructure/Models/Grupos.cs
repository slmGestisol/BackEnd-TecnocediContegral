using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Grupos
    {
        public long grupoId { get; set; }
        public string grupoCodigo { get; set; }
        public string grupoNombre { get; set; }
        public long puntoOperacionId { get; set; }

        public virtual PuntosOperaciones puntoOperacion { get; set; }
    }
}
