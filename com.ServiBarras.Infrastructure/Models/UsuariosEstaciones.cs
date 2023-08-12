using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UsuariosEstaciones
    {
        public long usuarioId { get; set; }
        public long estacionId { get; set; }

        public virtual Usuarios usuario { get; set; }
    }
}
