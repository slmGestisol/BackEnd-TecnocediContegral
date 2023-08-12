using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        public long roleId { get; set; }
        public string roleDescripcion { get; set; }
        public short roleEstado { get; set; }

        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
