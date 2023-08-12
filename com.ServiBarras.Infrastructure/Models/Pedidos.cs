using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
            PackingDetalle = new HashSet<PackingDetalle>();
            PedidosDetalle = new HashSet<PedidosDetalle>();
            PreRuteosPedidos = new HashSet<PreRuteosPedidos>();
            RuteosPedidos = new HashSet<RuteosPedidos>();
        }

        public long pedidoId { get; set; }
        public long sucursalId { get; set; }
        public int pedidoConsecutivo { get; set; }
        public DateTime pedidoFecha { get; set; }
        public DateTime pedidoFechaEntrega { get; set; }
        public DateTime pedidoFechaCarga { get; set; }
        public DateTime pedidoFechaMalla { get; set; }
        public string pedidoObservacion { get; set; }
        public string pedidoDocumentoERP { get; set; }
        public string pedidoConsecutivoERP { get; set; }
        public short pedidoVersion { get; set; }
        public byte pedidoEstado { get; set; }
        public string pedidoFuente { get; set; }
        public long? puntoOperacionId { get; set; }

        public virtual PuntosOperaciones puntoOperacion { get; set; }
        public virtual Sucursales sucursal { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
        public virtual ICollection<PedidosDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<PreRuteosPedidos> PreRuteosPedidos { get; set; }
        public virtual ICollection<RuteosPedidos> RuteosPedidos { get; set; }
    }
}
