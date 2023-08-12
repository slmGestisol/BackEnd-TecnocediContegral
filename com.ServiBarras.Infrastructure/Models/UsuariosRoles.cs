using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UsuariosRoles
    {
        public long usuarioId { get; set; }
        public long roleId { get; set; }

        public virtual Roles role { get; set; }
        public virtual Usuarios usuario { get; set; }
    }
}
