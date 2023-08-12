using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class InformeRuteosINFO1
    {
        public long ruteoINFOID { get; set; }
        public long? ruteoId { get; set; }
        public DateTime? ruteoFecha { get; set; }
        public int? ruteoConsecutivo { get; set; }
        public string ruteoPedidoEstado { get; set; }
        public long? pedidoId { get; set; }
        public long? bahiaId { get; set; }
        public string bahiaDescripcion { get; set; }
        public string pedidoProcesado { get; set; }
        public DateTime? ruteoPedidoFechaCreacion { get; set; }
        public DateTime? ruteoPedidoFechaCierre { get; set; }
    }
}
