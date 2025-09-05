using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RolesPermisos
    {
        public int rolId { get; set; }
        public int permisoId { get; set; }

        public virtual Permisos permiso { get; set; }
    }
}
