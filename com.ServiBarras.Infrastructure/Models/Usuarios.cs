using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Despachos = new HashSet<Despachos>();
            DespachosDetalle = new HashSet<DespachosDetalle>();
            Inventarios = new HashSet<Inventarios>();
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
            Packing = new HashSet<Packing>();
            UsuariosEstaciones = new HashSet<UsuariosEstaciones>();
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        public long usuarioId { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioIdentificacion { get; set; }
        public string usuarioApellido { get; set; }
        public Guid? usuarioGUID { get; set; }
        public string usuarioTerminal { get; set; }
        public short? usuarioUltPO { get; set; }
        public string usuarioUser { get; set; }
        public long? UbicacionIdUsuario { get; set; }
        public string usuarioPassword { get; set; }
        public long? instalacionId { get; set; }

        public virtual ICollection<Despachos> Despachos { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<Inventarios> Inventarios { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
        public virtual ICollection<Packing> Packing { get; set; }
        public virtual ICollection<UsuariosEstaciones> UsuariosEstaciones { get; set; }
        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
