using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PreRuteos
    {
        public PreRuteos()
        {
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
            PreRuteosPedidos = new HashSet<PreRuteosPedidos>();
        }

        public long preRuteoId { get; set; }
        public DateTime preRuteoFecha { get; set; }
        public string preRuteoUsuario { get; set; }
        public long preRuteoConsecutivo { get; set; }
        public long? documentoId { get; set; }
        public byte preRuteoPedidoEstado { get; set; }
        public long? instalacionId { get; set; }
        public int? EstibaCompletas { get; set; }

        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual ICollection<PreRuteosPedidos> PreRuteosPedidos { get; set; }
    }
}
