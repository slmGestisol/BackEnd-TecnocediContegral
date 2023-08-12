using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Devoluciones
    {
        public long devolucionId { get; set; }
        public long? ruteoId { get; set; }
        public long? presentacionId { get; set; }
        public long? puertaId { get; set; }
        public long? usuarioId { get; set; }
        public decimal? cantidadSalida { get; set; }
        public decimal? cantidadEntrada { get; set; }
        public long? novedadId { get; set; }
        public byte? estado { get; set; }
        public Guid devolucionProcesoId { get; set; }
        public long? pedidoId { get; set; }
        public long? usuarioIdTransaccion { get; set; }
        public byte? EstadoTransaccion { get; set; }
        public string proceso { get; set; }
    }
}
