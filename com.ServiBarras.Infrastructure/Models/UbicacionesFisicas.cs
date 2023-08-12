using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UbicacionesFisicas
    {
        public UbicacionesFisicas()
        {
            Ubicaciones = new HashSet<Ubicaciones>();
        }

        public long ubicacionFisicaId { get; set; }
        public string ubicacionFisicaCoordenada { get; set; }
        public byte ubicacionFisicaEstado { get; set; }
        public long coordenadaId { get; set; }

        public virtual Coordenadas coordenada { get; set; }
        public virtual ICollection<Ubicaciones> Ubicaciones { get; set; }
    }
}
