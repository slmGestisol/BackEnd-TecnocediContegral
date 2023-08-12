using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PuntosEnvio
    {
        public PuntosEnvio()
        {
            PedidosDetalle = new HashSet<PedidosDetalle>();
            Reglas = new HashSet<Reglas>();
        }

        public long puntoEnvioId { get; set; }
        public string puntoEnvioCodigo { get; set; }
        public string puntoEnvioNombre { get; set; }
        public long sucursalId { get; set; }
        public string puntoEnvioDireccion { get; set; }
        public long ciudadId { get; set; }
        public string puntoEnvioTelefono { get; set; }
        public string puntoEnvioCodigoEAN { get; set; }

        public virtual Ciudades ciudad { get; set; }
        public virtual Sucursales sucursal { get; set; }
        public virtual ICollection<PedidosDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<Reglas> Reglas { get; set; }
    }
}
