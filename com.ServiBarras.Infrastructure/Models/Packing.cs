using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Packing
    {
        public Packing()
        {
            PackingDetalle = new HashSet<PackingDetalle>();
        }

        public long packingId { get; set; }
        public DateTime packingFecha { get; set; }
        public long usuarioId { get; set; }
        public int packingConsecutivo { get; set; }
        public byte packingEstado { get; set; }
        public long? documentoId { get; set; }

        public virtual Usuarios usuario { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
    }
}
