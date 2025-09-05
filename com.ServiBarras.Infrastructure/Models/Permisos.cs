using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            RolesPermisos = new HashSet<RolesPermisos>();
        }

        public int permisoId { get; set; }
        public string permisoCodigo { get; set; }
        public string permisoDescripcion { get; set; }
        public string permisoLink { get; set; }
        public string permisoLinkParametro { get; set; }
        public string permisoLinkExterno { get; set; }
        public int? permisoOrden { get; set; }
        public bool? permisoEstado { get; set; }

        public virtual ICollection<RolesPermisos> RolesPermisos { get; set; }
    }
}
