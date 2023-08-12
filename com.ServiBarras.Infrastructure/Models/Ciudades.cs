using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            PuntosEnvio = new HashSet<PuntosEnvio>();
            PuntosOperaciones = new HashSet<PuntosOperaciones>();
            Sucursales = new HashSet<Sucursales>();
        }

        public long ciudadId { get; set; }
        public string ciudadCodigo { get; set; }
        public string ciudadCodigoDANE { get; set; }
        public string ciudadNombre { get; set; }
        public long estadoId { get; set; }

        public virtual Estados estado { get; set; }
        public virtual ICollection<PuntosEnvio> PuntosEnvio { get; set; }
        public virtual ICollection<PuntosOperaciones> PuntosOperaciones { get; set; }
        public virtual ICollection<Sucursales> Sucursales { get; set; }
    }
}
