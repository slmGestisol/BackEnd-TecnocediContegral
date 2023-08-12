using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Ruteos
    {
        public Ruteos()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
            PackingDetalle = new HashSet<PackingDetalle>();
            RuteosDetalle = new HashSet<RuteosDetalle>();
            RuteosPedidos = new HashSet<RuteosPedidos>();
        }

        public long ruteoId { get; set; }
        public DateTime ruteoFecha { get; set; }
        public string ruteoUsuario { get; set; }
        public long ruteoConsecutivo { get; set; }
        public long? documentoId { get; set; }
        public byte ruteoPedidoEstado { get; set; }
        public long? instalacionId { get; set; }

        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
        public virtual ICollection<RuteosDetalle> RuteosDetalle { get; set; }
        public virtual ICollection<RuteosPedidos> RuteosPedidos { get; set; }
    }
}
