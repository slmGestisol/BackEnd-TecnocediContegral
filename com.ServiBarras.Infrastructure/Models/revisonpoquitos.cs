using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class revisonpoquitos
    {
        public long id { get; set; }
        public long? UsuarioId { get; set; }
        public long? EstibaId { get; set; }
        public long? ContenedorId { get; set; }
        public long? PuertaId { get; set; }
        public long? PedidoId { get; set; }
        public bool? incompleto { get; set; }
        public DateTime? fecha { get; set; }
        public string Resultado { get; set; }
        public int? DDCantidad { get; set; }
        public int? DPCantidad { get; set; }
        public int? DpEstado { get; set; }
        public int? ddestado { get; set; }
        public int? DDUbicacionActual { get; set; }
        public int? DDCantidadsolicitada { get; set; }
    }
}
