using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ContenedoresDespachoParcial
    {
        public int contenedoresPickingId { get; set; }
        public long? usuarioId { get; set; }
        public long? EstibaId { get; set; }
        public long? ContenedorId { get; set; }
        public long? PuertaId { get; set; }
        public long? PedidoId { get; set; }
        public bool? Incomincompleto { get; set; }
        public Guid? uniqueProcessId { get; set; }
        public string respuesta { get; set; }
    }
}
