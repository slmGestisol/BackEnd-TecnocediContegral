using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Sucursales
    {
        public Sucursales()
        {
            Pedidos = new HashSet<Pedidos>();
            PuntosEnvio = new HashSet<PuntosEnvio>();
        }

        public long sucursalId { get; set; }
        public string sucursalCodigo { get; set; }
        public string sucursalNombre { get; set; }
        public long clienteId { get; set; }
        public string sucursalDireccion { get; set; }
        public long ciudadId { get; set; }
        public string sucursalTelefono { get; set; }
        public string sucursalCodigoEAN { get; set; }

        public virtual Ciudades ciudad { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual ICollection<PuntosEnvio> PuntosEnvio { get; set; }
    }
}
