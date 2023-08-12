using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Despachos
    {
        public Despachos()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
        }

        public long despachoId { get; set; }
        public DateTime despachoFecha { get; set; }
        public long usuarioId { get; set; }
        public int despachoConsecutivo { get; set; }
        public byte despachoEstado { get; set; }
        public long? documentoId { get; set; }

        public virtual Usuarios usuario { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
    }
}
