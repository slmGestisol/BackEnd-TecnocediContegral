using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class revisonpoquitos
    {
        public long ID { get; set; }
        public long? UsuarioId { get; set; }
        public long? EstibaId { get; set; }
        public long? ContenedorId { get; set; }
        public long? PuertaId { get; set; }
        public long? PedidoId { get; set; }
        public bool? incompleto { get; set; }
        public DateTime? fecha { get; set; }
        public Guid? process { get; set; }
        public long? DDUbicacionActual { get; set; }
        public long? DDCantidadsolicitada { get; set; }
        public long? DDCantidad { get; set; }
        public long? DPCantidad { get; set; }
        public long? DpEstado { get; set; }
        public long? ddestado { get; set; }
        public string ingreso { get; set; }
        public string RESULTADO { get; set; }
    }
}
